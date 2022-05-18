package cz.sedlardavid.a5pma.entities

import com.google.gson.annotations.SerializedName


data class ForecastData(
    @SerializedName("currently") val Currently: Forecast,
    @SerializedName("hourly") val Hourly: Hourly
)

data class Hourly(
    @SerializedName("data") val Data: List<Forecast>
)

data class Forecast(
    @SerializedName("time") val Time: String,
    @SerializedName("summary") val Summary: String,
    @SerializedName("icon") val Icon: String,
    @SerializedName("temperature") val Temperature: Double,
    @SerializedName("humidity") val Humidity: Double,
    @SerializedName("pressure") val Pressure: Double
)
