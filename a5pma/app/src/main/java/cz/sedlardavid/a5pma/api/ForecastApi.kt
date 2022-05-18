package cz.sedlardavid.a5pma.api

import android.content.Context
import android.net.ConnectivityManager
import android.os.AsyncTask
import androidx.appcompat.app.AppCompatActivity
import com.google.gson.Gson
import cz.sedlardavid.a5pma.controls.PrefsControl
import cz.sedlardavid.a5pma.entities.ForecastData
import org.json.JSONObject
import java.net.URL
import kotlin.properties.Delegates


class ForecastApi {

    lateinit var Units: String
    lateinit var Lang: String
    lateinit var Coords: String
    lateinit var City: String
    var OnlineMode: Boolean by Delegates.notNull<Boolean>()

    val Prefs: PrefsControl = PrefsControl.instance

    companion object {
        val instance = ForecastApi()
    }


    fun initAppParams(context: Context) {
        Units = Prefs.getString(context, "units") ?: "si"
        Lang = Prefs.getString(context, "lang") ?: "cs"
        Coords = Prefs.getString(context, "coords") ?: "49.22645,17.67065"
        City = Prefs.getString(context, "city") ?: "Zlín"
    }

    fun updateSettings(context: Context, data: Map<String, String>) {

        Units = data.get("units") as String
        City = data.get("city") as String
        Coords = if (OnlineMode) {
            try {
                GetCoordsFromCityTask(this).execute().get()
            } catch (e: Exception) {
                print("updateSettings: $e");
            } as String
        } else {
            Coords
        }

        Prefs.updateSettings(context, data)

    }

    fun verifyAvailableNetwork(activity: AppCompatActivity): Boolean {
        val connectivityManager =
            activity.getSystemService(Context.CONNECTIVITY_SERVICE) as ConnectivityManager
        val networkInfo = connectivityManager.activeNetworkInfo
        return networkInfo != null && networkInfo.isConnected
    }


}


class GetForecastTask(val forecastApi: ForecastApi) : AsyncTask<Void, Void, ForecastData>() {

    private val ApiKey: String = "5a32783cab327da3665110a93ecf2117"
    override fun doInBackground(vararg params: Void?): ForecastData? {
        val url =
            "https://api.darksky.net/forecast/" + ApiKey + "/" + forecastApi.Coords + "?" + "lang=" + forecastApi.Lang + "&units=" + forecastApi.Units
        val finalizedUrl = URL(url)
        var response: String = ""

        try {
            response = finalizedUrl.readText()
        } catch (e: Exception) {
            e.printStackTrace()
        }
        val gson = Gson()
        val forecast = gson.fromJson(response, ForecastData::class.java)
        return forecast
    }

}

class GetCityFromCoordsTask(val forecastApi: ForecastApi, val context: Context) :
    AsyncTask<Void, Void, String>() {

    private val ApiKey: String = "139678051580629283305x4042"
    val prefsControl: PrefsControl = PrefsControl.instance

    override fun doInBackground(vararg params: Void?): String? {
        val url: String =
            "https://geocode.xyz/${forecastApi.Coords}?json=1&auth=139678051580629283305x4042"
        val finalizedUrl = URL(url)
        var response: String = ""

        try {
            response = finalizedUrl.readText()
        } catch (e: Exception) {
            e.printStackTrace()
        }

        forecastApi.City = JSONObject(response).getString("city")
        prefsControl.setString(context, "city", forecastApi.City)
        return forecastApi.City
    }


}

class GetCoordsFromCityTask(val forecastApi: ForecastApi) :
    AsyncTask<Void, Void, String>() {

    private val ApiKey: String = "139678051580629283305x4042"
    val prefsControl: PrefsControl = PrefsControl.instance

    override fun doInBackground(vararg params: Void?): String? {
        val url: String =
            // "https://geocode.xyz/${forecastApi.City}?json=1&auth=139678051580629283305x4042"
            "https://geocode.xyz/${forecastApi.City}?json=1&auth=822218541728029524147x3865"
        val finalizedUrl = URL(url)
        var response: String = ""

        try {
            response = finalizedUrl.readText()
        } catch (e: Exception) {
            e.printStackTrace()
        }

        forecastApi.Coords =
            JSONObject(response).getJSONObject("alt").getJSONArray("loc").getJSONObject(0)
                .getString("latt") + "," + JSONObject(
                response
            ).getJSONObject("alt").getJSONArray("loc").getJSONObject(0).getString("longt")
        return forecastApi.Coords
    }


}

