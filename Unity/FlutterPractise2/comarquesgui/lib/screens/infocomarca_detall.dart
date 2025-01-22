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
    return Scaffold(
          body: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
                children: [ 
                  Padding(
                    padding: const EdgeInsets.only(
                      top: 40.0,
                      left: 10.0,
                      right: 10.0,
                      bottom: 10.0,),
                    child: MyWeatherInfo(),
                  ),
                  Padding(padding: const EdgeInsets.only(
                    left: 30,
                    top: 20,
                    right: 30,
                  ),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          children: [
                            const Expanded(
                              flex: 1,
                              child: Text("Població:", textAlign: TextAlign.left),
                            ),
                            Expanded(
                              flex: 1,
                              child: Text("${comarca.poblacio}", textAlign: TextAlign.left),
                            ),
                          ],
                        ),
                        Row(
                          children: [
                            const Expanded(
                              flex: 1,
                              child: Text("Latitud:", textAlign: TextAlign.left),
                            ),
                            Expanded(
                              flex: 1,
                              child: Text("${comarca.latitud}", textAlign: TextAlign.left),
                            ),
                          ],
                        ),
                        Row(
                          children: [
                            const Expanded(
                              flex: 1,
                              child: Text("Longitud:", textAlign: TextAlign.left),
                            ),
                            Expanded(
                              flex: 1,
                              child: Text("${comarca.longitud}", textAlign: TextAlign.left),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),

                ],
              ),
            ),
        );



// TO-DO
// Add the following information about the region:
// Population (number of inhabitants), latitude, and longitude.
// You can combine Column and Row to display the information in a tabular format.

// Before the information, it will be necessary to display the weather information 
// about the region using the custom widget MyWeatherInfo(), which has already been provided.

    return const Placeholder();
  }
}
