package cz.sedlardavid.a5pma

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.os.Handler

class SplashActivity : Activity() {
    private val SPLASH_DISPLAY_LENGTH = 1000

    public override fun onCreate(icicle: Bundle?) {
        super.onCreate(icicle)
        setContentView(R.layout.splash_screen)
        Handler()
            .postDelayed({
                val mainIntent = Intent(this@SplashActivity, MainActivity::class.java)
                this@SplashActivity.startActivity(mainIntent)
                finish()
            }, SPLASH_DISPLAY_LENGTH.toLong())
    }
}