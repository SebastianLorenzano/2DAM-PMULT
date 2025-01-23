
import 'package:comarquesgui/models/comarca.dart';
import 'package:comarquesgui/repository/repository_exemple.dart';
import 'package:flutter/material.dart';

class InfoComarcaGeneral extends StatelessWidget {
  const InfoComarcaGeneral({super.key});

  @override
  Widget build(BuildContext context) {

    // Agafem la comarca del repositori
    Comarca comarca = RepositoryExemple.obtenirInfoComarca();
        return Scaffold(
          body: Padding(
            padding: const EdgeInsets.only(
              left: 15.0,
              right: 15.0),
            child: SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                  children: [ 
                    SizedBox(
                      height: 90),
                    Image.network(
                      comarca.img!,  
                      alignment: Alignment.center,
                      width: double.infinity, height: 250,
                      fit: BoxFit.cover),
                    Padding(
                      padding: const EdgeInsets.only(
                        top: 45.0,
                        left: 20.0,
                        right: 20.0,
                        bottom: 20.0,
                        ),
                      child: Text(comarca.comarca, style: Theme.of(context).textTheme.headlineLarge),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(
                        left: 20.0,
                        right: 20.0,
                        bottom: 30.0,
                        ),
                      child: Text("Capital: ${comarca.capital!}", style: Theme.of(context).textTheme.headlineMedium),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(
                        left: 20.0,
                        right: 20.0,
                        ),
                      child: Text(comarca.desc!, style: Theme.of(context).textTheme.headlineSmall, textAlign: TextAlign.justify),
                    ),
                  ],
                ),
              ),
          ),
        );
  }
}
