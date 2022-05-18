package cz.sedlardavid.a5pma

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.ImageButton
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import cz.sedlardavid.a5pma.api.ForecastApi
import cz.sedlardavid.a5pma.api.GetCityFromCoordsTask
import cz.sedlardavid.a5pma.api.GetForecastTask
import cz.sedlardavid.a5pma.controls.PrefsControl
import cz.sedlardavid.a5pma.entities.ForecastData
import java.text.SimpleDateFormat
import java.util.*


class MainActivity : AppCompatActivity() {


    private val forecastApi: ForecastApi = ForecastApi.instance
    private val prefs: PrefsControl = PrefsControl.instance

    private lateinit var btnForecast: Button
    private lateinit var btnSetting: ImageButton
    private lateinit var txtCityName: TextView
    private lateinit var txtCurrentTemperature: TextView
    private lateinit var txtCurrentDateTime: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        forecastApi.initAppParams(this)
            .let { forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this) }

        btnForecast = findViewById(R.id.btnForecast)
        btnSetting = findViewById(R.id.btnSettings)
        txtCityName = findViewById(R.id.idCityName)
        txtCurrentTemperature = findViewById(R.id.idCurrentTemperature)
        txtCurrentDateTime = findViewById(R.id.idLocalDateTime)



        btnForecast.setOnClickListener {
            val forecast = Intent(this@MainActivity, ForecastActivity::class.java)
            startActivity(forecast)
        }

        btnSetting.setOnClickListener {
            val setting = Intent(this@MainActivity, SettingsActivity::class.java)
            startActivity(setting)
        }

        _fillLabels()


    }

    override fun onResume() {
        super.onResume()
        forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this)
        _fillLabels()

    }

    private fun _fillLabels(
    ) {
        txtCityName.text =
            if (!prefs.containsKey(this, "city")) "Zlín" else prefs.getString(this, "city")
                ?: if (forecastApi.OnlineMode) {
                    GetCityFromCoordsTask(
                        forecastApi,
                        this
                    ).execute().get()
                } else {
                    "Zlín"
                }

        txtCurrentTemperature.text = if (forecastApi.OnlineMode) {
            getCurrentForecast().Currently.Temperature.toString()
                .substringBefore('.') + if (forecastApi.Units == "si") {
                "°C"
            } else {
                "F"
            }
        } else {
            ""
        }


        txtCurrentDateTime.text = getDate()
    }

    private fun getCurrentForecast(): ForecastData {
        return GetForecastTask(forecastApi).execute().get()
    }

    private fun getDate(
    ): String? {
        val formatter = SimpleDateFormat("dd.MM HH:mm")
        return formatter.format(Date())
    }


}
