package com.example.stardewvalley;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class Personagens extends AppCompatActivity {

    private Button botaoWeb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_personagens);

    }
    public void personagens(View view) {
        Intent in = new Intent(Personagens.this, MainActivity.class);
        startActivity(in);
    }
}

