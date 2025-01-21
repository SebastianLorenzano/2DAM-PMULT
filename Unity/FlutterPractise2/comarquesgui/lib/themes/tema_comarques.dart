import 'package:flutter/material.dart';

ThemeData temaComarques = ThemeData(
  textTheme: const TextTheme(
      displayLarge: TextStyle(
        fontFamily: "LeckerliOne",
        fontSize: 36,
        fontWeight: FontWeight.w100,
      ),
      displayMedium: TextStyle(
          fontWeight: FontWeight.w300,
          color: Colors.white,
          fontFamily: "LeckerliOne",
          fontSize: 40,
          shadows: [
            Shadow(offset: Offset(2, 2), color: Colors.black, blurRadius: 3),
          ]),
      displaySmall: TextStyle(
          fontWeight: FontWeight.w300,
          color: Colors.white,
          fontFamily: "LeckerliOne",
          fontSize: 25,
          shadows: [
            Shadow(offset: Offset(2, 2), color: Colors.black, blurRadius: 3),
          ]),
      headlineLarge: TextStyle(
          fontWeight: FontWeight.bold,
          color: Colors.black,
          fontFamily: "Roboto",  
          fontSize: 18,
          ),

      headlineMedium: TextStyle(
          fontWeight: FontWeight.w400,
          color: Colors.black87,
          fontFamily: "Roboto",  // A good serif alternative could be "Merriweather"
          fontSize: 16  ,
      ),

      headlineSmall:  TextStyle(
          fontWeight: FontWeight.w200,
          color: Colors.black87,
          fontFamily: "OpenSans",  // Replace with "Nunito" for a softer look
          fontSize: 12,
          height: 1.5,  // Adjust line height for readability
      )
  ),
);
