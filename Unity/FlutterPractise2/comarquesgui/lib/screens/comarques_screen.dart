import 'package:comarquesgui/repository/repository_exemple.dart';
import 'package:comarquesgui/screens/infocomarca_main.dart';
import 'package:flutter/material.dart';

class ComarquesScreen extends StatelessWidget {
  const ComarquesScreen({
    super.key,
    required this.provincia,
    });

  final String provincia;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(provincia == 'Alacant' ? "Comarques d'$provincia" : 'Comarques de $provincia', style: Theme.of(context).textTheme.labelSmall),
      ),
      body: Padding(
        padding: const EdgeInsets.all(15.0),
        child: Center(
            // Proporciona a _creaLlistaComarques la llista de comarques d'Alacant
            child:
                _creaLlistaComarques(RepositoryExemple.obtenirComarques(provincia))),
      ), ////
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
    return GestureDetector(
      onTap: () => {
        Navigator.push(context, MaterialPageRoute(builder:(context) => InfocomarcaMain(comarcaString: comarca,)))
      },
      child: Card(
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
      ),
    );
  }
}
