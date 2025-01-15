import 'package:comarquesgui/models/comarca.dart';
import 'package:comarquesgui/repository/repository_exemple.dart';
import 'package:flutter/material.dart';

class ComarquesScreen extends StatelessWidget {
  const ComarquesScreen();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
          // Proporciona a _creaLlistaComarques la llista de comarques d'Alacant
          child:
              _creaLlistaComarques(RepositoryExemple.obtenirComarques())), ////
    );
  }

  _creaLlistaComarques(List<dynamic> comarques) {
    return ListView.builder(
      itemCount: comarques.length,
      itemBuilder: (context, index) {
        return ComarcaCard(
          comarca: comarques[index]["nom"] ?? "",
          img: comarques[index]["img"] ?? "",
        );
      },
    );
  }
// We receive the list of JSON objects with the name and image (img) of each region

// TO-DO
// It will be necessary to use a ListView.builder to iterate through the list
// and generate a custom widget of type ComarcaCard, with the image and name.


    // Rebem la llista de JSON amb el nom i la imatge (img) de cada comarca

    // TO-DO
    // Caldrà fer ús d'un ListView.builder per recórrer la llista
    // i generar un giny personalitzat de tipus ComarcaCard, amb la imatge i el nom.
  
}

class ComarcaCard extends StatelessWidget {
  // Aquest giny rebrà dos arguments amb nom per construir-se:
  // la imatge (img) i el nom de la comarca (comarca)
  const ComarcaCard({
    super.key,
    required this.img,
    required this.comarca,
  });

  final String img;
  final String comarca;

  @override
  Widget build(BuildContext context) {
    return Card(
      child: 
      Stack(
        children: [
          Image.network(img,
              width: double.infinity, height: 200, fit: BoxFit.cover),
              
          Positioned(
            bottom: 10,
            left: 10,
            child: Text(comarca, style: Theme.of(context).textTheme.displayMedium
            ))
        ],
      ),
    );
    // TO-DO
// Returns a widget of type Card, with the desired design,
// but it should display the image (fetched from the Internet using the URL)
// and the name of the comarca.

    // TO-DO
    // Retorna un giny de tipus Card, amb el disseny que desitgeu, però
    // que mostre la imatge (obtinguda d'Internet a partir de la url)
    // i el nom de la comarca.
  }
}
