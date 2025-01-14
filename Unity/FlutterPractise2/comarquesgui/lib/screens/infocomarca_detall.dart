import 'package:comarquesgui/models/comarca.dart';
import 'package:comarquesgui/repository/repository_exemple.dart';
import 'package:comarquesgui/screens/widgets/my_weather_info.dart';
import 'package:flutter/material.dart';

class InfoComarcaDetall extends StatelessWidget {
  const InfoComarcaDetall({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    Comarca comarca = RepositoryExemple.obtenirInfoComarca();

    // TO-DO
    // Afegir la informació següent sobre la comarca:
    // Població (num. d'habitants), latitud i longitud.
    // Podeu combinar Column i Row per mostrar la informació tabulada

    // Abans de la informació, caldrà mostrar la informació sobre l'oratge a la comarca,
    // mitjançant el widget personalitzat MyWeatherInfo(), que se us proporciona ja implementat
    return const Placeholder();
  }
}
