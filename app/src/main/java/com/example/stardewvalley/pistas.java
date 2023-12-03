package com.example.stardewvalley;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class pistas extends AppCompatActivity {

    private Button botaoWeb;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pistas);

    }

    public void MainActivity(View view) {
        Intent in = new Intent(pistas.this, MainActivity.class);
        startActivity(in);
    }
}