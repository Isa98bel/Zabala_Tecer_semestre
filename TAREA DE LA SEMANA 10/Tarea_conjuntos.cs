#include <iostream>
#include <set>
#include <vector>
#include <algorithm>
#include <fstream>

using namespace std;

int main() {
    // Conjuntos ficticios de ciudadanos
    set<int> todosLosCiudadanos;
    set<int> vacunadosPfizer;
    set<int> vacunadosAstrazeneca;
    set<int> vacunadosCompletos;

    // Generar los datos ficticios
    for (int i = 1; i <= 500; i++) {
        todosLosCiudadanos.insert(i);
    }
    for (int i = 1; i <= 75; i++) {
        vacunadosPfizer.insert(i);
    }
    for (int i = 76; i <= 150; i++) {
        vacunadosAstrazeneca.insert(i);
    }

    // Simular que algunos ciudadanos han recibido ambas vacunas
    for (int i = 151; i <= 200; i++) {
        vacunadosPfizer.insert(i);
        vacunadosAstrazeneca.insert(i);
        vacunadosCompletos.insert(i);
    }

    // Operaciones para encontrar los diferentes conjuntos requeridos
    set<int> noVacunados;
    set_difference(todosLosCiudadanos.begin(), todosLosCiudadanos.end(),
                   vacunadosPfizer.begin(), vacunadosPfizer.end(),
                   inserter(noVacunados, noVacunados.begin()));
    set_difference(noVacunados.begin(), noVacunados.end(),
                   vacunadosAstrazeneca.begin(), vacunadosAstrazeneca.end(),
                   inserter(noVacunados, noVacunados.begin()));

    set<int> soloPfizer;
    set_difference(vacunadosPfizer.begin(), vacunadosPfizer.end(),
                   vacunadosAstrazeneca.begin(), vacunadosAstrazeneca.end(),
                   inserter(soloPfizer, soloPfizer.begin()));

    set<int> soloAstrazeneca;
    set_difference(vacunadosAstrazeneca.begin(), vacunadosAstrazeneca.end(),
                   vacunadosPfizer.begin(), vacunadosPfizer.end(),
                   inserter(soloAstrazeneca, soloAstrazeneca.begin()));

    // Reportar resultados
    cout << "Ciudadanos que no se han vacunado: " << noVacunados.size() << endl;
    cout << "Ciudadanos que han recibido las dos vacunas: " << vacunadosCompletos.size() << endl;
    cout << "Ciudadanos que solamente han recibido la vacuna de Pfizer: " << soloPfizer.size() << endl;
    cout << "Ciudadanos que solamente han recibido la vacuna de Astrazeneca: " << soloAstrazeneca.size() << endl;

    // Exportar resultados a un archivo de texto
    ofstream reporte("reporte_vacunacion.txt");
    if (reporte.is_open()) {
        reporte << "Reporte de Vacunación COVID-19\n\n";
        reporte << "Ciudadanos que no se han vacunado: " << noVacunados.size() << endl;
        reporte << "Ciudadanos que han recibido las dos vacunas: " << vacunadosCompletos.size() << endl;
        reporte << "Ciudadanos que solamente han recibido la vacuna de Pfizer: " << soloPfizer.size() << endl;
        reporte << "Ciudadanos que solamente han recibido la vacuna de Astrazeneca: " << soloAstrazeneca.size() << endl;
        reporte.close();
        cout << "Reporte guardado en 'reporte_vacunacion.txt'." << endl;
    } else {
        cout << "No se pudo crear el archivo de reporte." << endl;
    }

    return 0;
}
