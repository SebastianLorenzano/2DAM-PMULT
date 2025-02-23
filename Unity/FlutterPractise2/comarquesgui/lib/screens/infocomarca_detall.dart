import 'package:comarquesgui/models/comarca.dart';
import 'package:comarquesgui/repository/repository_comarques.dart';
import 'package:comarquesgui/screens/widgets/my_circular_progress_indicator.dart';
import 'package:comarquesgui/screens/widgets/my_weather_info.dart';
import 'package:flutter/material.dart';

class InfoComarcaDetall extends StatelessWidget {
  const InfoComarcaDetall({
    super.key,
    required this.comarcaString,
  });
  final String comarcaString;

  @override
  Widget build(BuildContext context) {
    // Afegir la informació següent sobre la comarca:
    // Població (num. d'habitants), latitud i longitud.
    // Podeu combinar Column i Row per mostrar la informació tabulada

    // Abans de la informació, caldrà mostrar la informació sobre l'oratge a la comarca,
    // mitjançant el widget personalitzat MyWeatherInfo(), que se us proporciona ja implementat
    return FutureBuilder(
      future: RepositoryComarques.obtenirInfoComarca(comarcaString),
      builder: (BuildContext context, AsyncSnapshot snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: MyCircularProgressIndicator(),
          );
        }
        if (snapshot.hasError) {
          return const Center(
            child: Text('Error al carregar la comarca'),
          );
        }
        Comarca? comarca = snapshot.data;
        return Center(
          child: comarca != null ? _crearInfoComarca(context, comarca) : const Placeholder(),
        );
      }
    );
  }

  Widget _crearInfoComarca(BuildContext context, Comarca comarca) {
    var estiloTexto = const TextStyle(fontSize: 25,);
    return SingleChildScrollView(
      child: Container(
        decoration: const BoxDecoration(
          color: Color.fromRGBO(255, 251, 255, 1),
        ),
          padding: const EdgeInsets.only(top: 0, bottom: 80, left: 20, right: 20),
        child: Container(
          decoration: const BoxDecoration(
        color: Color.fromRGBO(254, 254, 254, 1),
      ),
      child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          MyWeatherInfo(latitud: comarca.latitud, longitud: comarca.longitud),
          const SizedBox(height: 40),
          Container(
            padding: const EdgeInsets.only(left: 30, right: 30),
            child: Table(
              children: [
                TableRow(
                  children: [
                    Text("Població:", style: estiloTexto),
                    Text(comarca.poblacio.toString(), style: estiloTexto,)
                  ]
                ),
                TableRow(
                  children: [
                    Text("Latitud:", style: estiloTexto,),
                    Text(comarca.latitud.toString(), style: estiloTexto,)
                  ]
                ),
                TableRow(
                  children: [
                    Text("Longitud:", style: estiloTexto,),
                    Text(comarca.longitud.toString(), style: estiloTexto,)
                  ]
                )
              ],
            ),
          )
        ],
      )
      )
        ),
    );
  }
}
