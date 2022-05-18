package cz.sedlardavid.a5pma.controls

import android.content.Context
import android.content.SharedPreferences

class PrefsControl {

    private val PREFS_NAME = "a5pma-forecast"

    private fun getSharedPreferences(context: Context): SharedPreferences {
        return context.getSharedPreferences(PREFS_NAME, Context.MODE_PRIVATE)
    }

    fun getString(context: Context, key: String): String? {
        return getSharedPreferences(context).getString(key, null)
    }

    fun containsKey(context: Context, key: String): Boolean {
        return getSharedPreferences(context).contains(key)
    }

    fun setString(context: Context, key: String, newValue: String) {
        val editor = getSharedPreferences(context).edit()
        editor.putString(key, newValue)
        editor.apply()
    }

    fun updateSettings(context: Context, data: Map<String, String>) {
        val editor = getSharedPreferences(context).edit()
        data.forEach { (k, v) -> editor.putString(k, v) }
        editor.apply()
    }

    companion object {
        val instance = PrefsControl()
    }

}