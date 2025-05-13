package ec.edu.monster.convertidortemperaturaclientemovil;

import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;
import ec.edu.monster.convertionclient.GPTBasicHttpBinding_IConversion;
import ec.edu.monster.convertionclient.GPTCredentials;
import java.net.UnknownHostException;

public class MainActivity extends AppCompatActivity {

    private EditText inputUserName, inputPassword, inputTemperature;
    private TextView resultTextView, loginStatusTextView, conversionTitleTextView;
    private Button buttonLogin, buttonCelsiusToFahrenheit, buttonFahrenheitToCelsius;
    private boolean isLoggedIn = false;

    private static final String TAG = "TemperatureConverter";
    private static final String SERVICE_URL = "http://192.168.100.23:50176/ec.edu.monster.controlador/Conversion.svc";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Inicializar elementos de login
        inputUserName = findViewById(R.id.inputUserName);
        inputPassword = findViewById(R.id.inputPassword);
        loginStatusTextView = findViewById(R.id.loginStatusTextView);
        buttonLogin = findViewById(R.id.buttonLogin);

        // Inicializar elementos de conversión (ocultos inicialmente)
        conversionTitleTextView = findViewById(R.id.conversionTitleTextView);
        inputTemperature = findViewById(R.id.inputTemperature);
        resultTextView = findViewById(R.id.resultTextView);
        buttonCelsiusToFahrenheit = findViewById(R.id.buttonCelsiusToFahrenheit);
        buttonFahrenheitToCelsius = findViewById(R.id.buttonFahrenheitToCelsius);

        // Ocultar panel de conversión inicialmente
        conversionTitleTextView.setVisibility(View.GONE);
        inputTemperature.setVisibility(View.GONE);
        resultTextView.setVisibility(View.GONE);
        buttonCelsiusToFahrenheit.setVisibility(View.GONE);
        buttonFahrenheitToCelsius.setVisibility(View.GONE);

        // Listener para el botón de login
        buttonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String userName = inputUserName.getText().toString();
                String password = inputPassword.getText().toString();
                if (!userName.isEmpty() && !password.isEmpty()) {
                    new LoginTask().execute(userName, password);
                } else {
                    loginStatusTextView.setText("Please enter username and password");
                }
            }
        });

        // Listener para el botón Celsius a Fahrenheit
        buttonCelsiusToFahrenheit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String tempStr = inputTemperature.getText().toString();
                if (!tempStr.isEmpty()) {
                    try {
                        double temperature = Double.parseDouble(tempStr);
                        new ConvertTemperatureTask(true).execute(temperature);
                    } catch (NumberFormatException e) {
                        resultTextView.setText("Please enter a valid number");
                    }
                } else {
                    resultTextView.setText("Please enter a temperature");
                }
            }
        });

        // Listener para el botón Fahrenheit a Celsius
        buttonFahrenheitToCelsius.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String tempStr = inputTemperature.getText().toString();
                if (!tempStr.isEmpty()) {
                    try {
                        double temperature = Double.parseDouble(tempStr);
                        new ConvertTemperatureTask(false).execute(temperature);
                    } catch (NumberFormatException e) {
                        resultTextView.setText("Please enter a valid number");
                    }
                } else {
                    resultTextView.setText("Please enter a temperature");
                }
            }
        });
    }

    // AsyncTask para manejar el login
    private class LoginTask extends AsyncTask<String, Void, Boolean> {
        @Override
        protected Boolean doInBackground(String... params) {
            String userName = params[0];
            String password = params[1];
            try {
                GPTBasicHttpBinding_IConversion service = new GPTBasicHttpBinding_IConversion(SERVICE_URL);
                service.setLoggingEnabled(true);

                // Crear objeto GPTCredentials
                GPTCredentials credentials = new GPTCredentials();
                credentials.setUsername(userName);
                credentials.setPassword(password);

                // Llamar al método Login
                return service.Login(credentials);
            } catch (Exception e) {
                Log.e(TAG, "Login error: " + e.getMessage(), e);
                return false;
            }
        }

        @Override
        protected void onPostExecute(Boolean success) {
            if (success) {
                loginStatusTextView.setText("Login successful");
                isLoggedIn = true;
                // Mostrar panel de conversión
                inputUserName.setVisibility(View.GONE);
                inputPassword.setVisibility(View.GONE);
                buttonLogin.setVisibility(View.GONE);
                loginStatusTextView.setVisibility(View.GONE);
                conversionTitleTextView.setVisibility(View.VISIBLE);
                inputTemperature.setVisibility(View.VISIBLE);
                resultTextView.setVisibility(View.VISIBLE);
                buttonCelsiusToFahrenheit.setVisibility(View.VISIBLE);
                buttonFahrenheitToCelsius.setVisibility(View.VISIBLE);
            } else {
                loginStatusTextView.setText("Login failed. Please try again.");
            }
        }
    }

    // AsyncTask para manejar la conversión de temperaturas
    private class ConvertTemperatureTask extends AsyncTask<Double, Void, String> {
        private boolean isCelsiusToFahrenheit;

        public ConvertTemperatureTask(boolean isCelsiusToFahrenheit) {
            this.isCelsiusToFahrenheit = isCelsiusToFahrenheit;
        }

        @Override
        protected void onPreExecute() {
            buttonCelsiusToFahrenheit.setEnabled(true);
            buttonFahrenheitToCelsius.setEnabled(true);
        }

        @Override
        protected String doInBackground(Double... params) {
            double temperature = params[0];
            try {
                if (isCelsiusToFahrenheit) {
                    GPTBasicHttpBinding_IConversion service = new GPTBasicHttpBinding_IConversion(SERVICE_URL);
                    service.setLoggingEnabled(true);
                    Double result = service.ConvertirCelsiusAFahrenheit(temperature);
                    return result != null ? String.format("%.2f", result) : "Error: No result";
                } else {
                    // Convertir manualmente de Fahrenheit a Celsius
                    double result = (temperature - 32) * 5 / 9;
                    return String.format("%.2f", result);
                }
            } catch (UnknownHostException e) {
                return "Connection lost. Please check your network.";
            } catch (Exception e) {
                return "Error: " + e.getMessage();
            }
        }

        @Override
        protected void onPostExecute(String result) {
            if (result.startsWith("Connection lost")) {
                resultTextView.setText(result);
                buttonCelsiusToFahrenheit.setEnabled(false);
                buttonFahrenheitToCelsius.setEnabled(false);
            } else if (result.startsWith("Error")) {
                resultTextView.setText(result);
            } else if (isCelsiusToFahrenheit) {
                resultTextView.setText("Result: " + result + " °F");
                buttonCelsiusToFahrenheit.setEnabled(true);
                buttonFahrenheitToCelsius.setEnabled(true);
            } else {
                resultTextView.setText("Result: " + result + " °C");
                buttonCelsiusToFahrenheit.setEnabled(true);
                buttonFahrenheitToCelsius.setEnabled(true);
            }
        }
    }
}