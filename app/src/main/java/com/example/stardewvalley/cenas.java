package com.example.stardewvalley;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class cenas extends AppCompatActivity {

    private Button botaoWeb;
    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cenas);
    }
    public void MainActivity(View view) {
        Intent in = new Intent(cenas.this, MainActivity.class);
        startActivity(in);
    }
}