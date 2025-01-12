class Comarca {
    late String comarca;
    String? 
     capital,
     poblacio,
     img,
     desc;
    double? 
     latitud,
     longitud;


    Comarca({
        required this.comarca,
        this.capital,
        this.poblacio,
        this.img,
        this.desc,
        this.latitud,
        this.longitud,
        });
    
    Comarca.fromJSON(Map<String, dynamic> json) {
        comarca = json["comarca"] ?? "";
        capital = json["capital"] ?? "";
        poblacio = json["poblacio"] ?? "";
        img = json["img"] ?? "";
        desc = json["desc"] ?? "";
        latitud = json["latitud"] ?? "";
        longitud = json["longitud"] ?? "";
    }

    @override
  String toString() {
    return '''\x1B[34mComarca:\t\x1B[31m$comarca\n\x1B[34mCapital:\t\x1B[31m$capital\n\x1B[34mPoblacio:\t\x1B[31m$poblacio\x1B[34m\n\nImatge:\t\t\x1B[31m$img\n\x1B[34mDescripció:\t\x1B[31m$desc\n\x1B[34mCoordenades:\t\x1B[31m($latitud, $longitud)\n\x1B[0m''';
  }
  
}

