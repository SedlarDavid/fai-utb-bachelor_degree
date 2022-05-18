package cz.sedlardavid.a5pma

import android.os.Bundle
import android.view.View
import android.widget.RelativeLayout
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import cz.sedlardavid.a5pma.api.ForecastAdapter
import cz.sedlardavid.a5pma.api.ForecastApi
import cz.sedlardavid.a5pma.api.GetForecastTask
import cz.sedlardavid.a5pma.entities.Forecast
import cz.sedlardavid.a5pma.entities.ForecastData


class ForecastActivity : AppCompatActivity() {

    private val forecastApi: ForecastApi = ForecastApi.instance
    private lateinit var forecast: ForecastData
    private lateinit var noInternetLayout: RelativeLayout
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_forecast)

        noInternetLayout = findViewById(R.id.noInternetLayout)

        forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this)

        GetForecast()
    }

    override fun onResume() {
        super.onResume()

        forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this)
    }

    private fun GetForecast() {
        if (forecastApi.OnlineMode) {
            forecast = GetForecastTask(forecastApi).execute().get()
            val arrayList = arrayListOf<Forecast>()
            arrayList.addAll(forecast.Hourly.Data)
            prepareRecyclerView(arrayList)

        } else {

            noInternetLayout.visibility = View.VISIBLE
            noInternetLayout.setOnClickListener { true }
            noInternetLayout.setOnTouchListener { v, event -> true }
        }
    }


    private fun prepareRecyclerView(arrayList: ArrayList<Forecast>) {
        val recyclerView: RecyclerView = findViewById(R.id.forecast_list_view)
        val recyclerViewAdapter =
            ForecastAdapter(arrayList, forecastApi, this)
        recyclerView.adapter = recyclerViewAdapter
        recyclerView.layoutManager = LinearLayoutManager(this)
    }

}