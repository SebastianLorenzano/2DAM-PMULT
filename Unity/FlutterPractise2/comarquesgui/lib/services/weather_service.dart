import 'dart:io';
import 'package:http/http.dart' as http;
import 'dart:convert';


class WeatherService {
  static Future<dynamic> obteClima(
      {required double longitud, required double latitud}) async {
    String url = 'https://api.open-meteo.com/v1/forecast?latitude=$latitud&longitude=$longitud&current_weather=true';

    // Llancem una petició GET mitjançant el mètode http.get, i ens esperem a la resposta
    http.Response response = await http.get(Uri.parse(url));

    if (response.statusCode == HttpStatus.ok) {
      // Descodifiquem la resposta
      String body = utf8.decode(response.bodyBytes);
      final result = jsonDecode(body);

      // I la tornem
      return result;
    } else {
      // Si no carrega, llancem una excepció
      throw Exception('No s\'ha pogut connectar');
    }
  }
}