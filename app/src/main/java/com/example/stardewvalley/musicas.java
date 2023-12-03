package com.example.stardewvalley;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class musicas extends AppCompatActivity {

    Button botaoWeb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_musicas);

        botaoWeb = (Button) findViewById(R.id.button_musicas);

        botaoWeb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(Intent.ACTION_VIEW, Uri.parse("https://www.youtube.com/watch?v=0h0HS5DfIkQ")));
            }
        });
    }
    public void MainActivity(View view) {
        Intent in = new Intent(musicas.this, MainActivity.class);
        startActivity(in);
    }
}