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
              width: double.infinity, height: 225, fit: BoxFit.cover),        
          Positioned(
            bottom: 10,
            left: 10,
            child: Text(comarca, style: Theme.of(context).textTheme.displaySmall,
            ))
        ],
      ),
    );
  }
}
