package cz.sedlardavid.a5pma

import android.os.Bundle
import android.view.View
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import cz.sedlardavid.a5pma.api.ForecastApi
import cz.sedlardavid.a5pma.controls.PrefsControl
import kotlinx.android.synthetic.main.activity_settings.*


class SettingsActivity : AppCompatActivity() {

    private val forecastApi: ForecastApi = ForecastApi.instance
    val prefs: PrefsControl = PrefsControl.instance
    lateinit var units: Spinner
    lateinit var txtCity: EditText
    lateinit var btnSave: Button
    lateinit var progressOverlay: RelativeLayout
    lateinit var btnNetwork: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_settings)


        forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this)

        units = findViewById(R.id.txtUnits)
        txtCity = findViewById(R.id.txtCity)
        btnSave = findViewById(R.id.btnSave)
        progressOverlay = findViewById(R.id.progressOverlay)
        btnNetwork = findViewById(R.id.btnNetwork)

        _loadParams()

        btnNetwork.setOnClickListener {
            forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this)
            val toast = if (forecastApi.OnlineMode) {
                Toast.makeText(this, getString(R.string.network_online), Toast.LENGTH_SHORT)
            } else {
                Toast.makeText(this, getString(R.string.network_offline), Toast.LENGTH_LONG)
            }
            toast.show()
        }

        btnSave.setOnClickListener {
            _updateSettings()
        }
    }

    override fun onResume() {
        super.onResume()

        forecastApi.OnlineMode = forecastApi.verifyAvailableNetwork(this)
    }

    private fun _loadParams() {
        var initUnits: Int
        ArrayAdapter.createFromResource(
            this,
            R.array.units,
            android.R.layout.simple_spinner_item
        ).also { adapter ->
            val uni: String = if (forecastApi.Units == "si") {
                "Metrics"
            } else {
                "Imperial"
            }
            adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
            initUnits = adapter.getPosition(uni)
            units.adapter = adapter
        }

        txtCity.setText(forecastApi.City)
        units.setSelection(initUnits)
    }


    private fun _updateSettings() {
        progressOverlay.visibility = View.VISIBLE
        progressOverlay.setOnClickListener { true }
        progressOverlay.setOnTouchListener { v, event -> true }
        val units = resources.getStringArray(R.array.units)
        val data = mapOf(
            "units" to if (txtUnits.selectedItem == units[0]) {
                "si"
            } else {
                "us"
            },
            "city" to txtCity.text.toString()
        )
        forecastApi.updateSettings(this, data)

        progressOverlay.visibility = View.INVISIBLE
        val toast = if (forecastApi.OnlineMode) {
            Toast.makeText(this, getString(R.string.saved), Toast.LENGTH_SHORT)
        } else {
            Toast.makeText(this, getString(R.string.city_network_error), Toast.LENGTH_LONG)
        }

        toast.show()
    }


}