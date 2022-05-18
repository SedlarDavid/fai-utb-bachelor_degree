package cz.sedlardavid.a5pma.api

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.RelativeLayout
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import cz.sedlardavid.a5pma.R
import cz.sedlardavid.a5pma.entities.Forecast
import java.text.SimpleDateFormat
import java.util.*
import kotlin.math.round


class ForecastAdapter(
    private val dataSource: ArrayList<Forecast>,
    private val forecastApi: ForecastApi,
    private val context: Context
) :
    RecyclerView.Adapter<ForecastAdapter.ViewHolder>() {

    class ViewHolder(view: View, context: Context) : RecyclerView.ViewHolder(view) {

        private var wholeLayoutItem: RelativeLayout? = null
        var txtTime: TextView? = null
        var txtSummary: TextView? = null
        var txtTemperature: TextView? = null
        var imgIcon: ImageView? = null

        fun myViewHolder(itemView: View) {
            wholeLayoutItem = itemView.findViewById(R.id.lay_forecast_item)
            txtTime = itemView.findViewById(R.id.forecast_list_time)
            txtSummary = itemView.findViewById(R.id.forecast_list_summary)
            txtTemperature = itemView.findViewById(R.id.forecast_list_temperature)
            imgIcon = itemView.findViewById(R.id.forecast_list_thumbnail)
        }

        init {
            myViewHolder(view)
        }


    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {

        val view: View =
            LayoutInflater.from(parent.context).inflate(R.layout.list_item_forecast, parent, false)

        val myVH = ViewHolder(view, context)

        return myVH
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.txtTime?.text = getDate(dataSource[position].Time.toLong(), "dd.MM HH:mm").toString()
        holder.txtTemperature?.text =
            round(dataSource[position].Temperature).toString().substringBefore('.') + if (forecastApi.Units == "si") {
                "°C"
            } else {
                "F"
            }
        holder.txtSummary?.text = dataSource[position].Summary

        holder.imgIcon?.setImageResource(
            context.resources.getIdentifier(
                dataSource[position].Icon.replace(
                    '-',
                    '_'
                ).replace('-', '_'), "drawable", context.packageName
            )
        )
    }

    override fun getItemCount(): Int {
        return dataSource.size
    }

    fun getItem(position: Int): Any {
        return dataSource[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    fun getDate(
        milliSeconds: Long,
        dateFormat: String?
    ): String? {
        val formatter = SimpleDateFormat(dateFormat)
        val calendar = Calendar.getInstance()
        calendar.timeInMillis = milliSeconds * 1000
        return formatter.format(calendar.time)
    }


}