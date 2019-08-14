import net.sf.jni4net.Bridge;
import directcoupling.Program;

import java.io.File;

public class App {
    public static void main(String[] args) throws Exception {

        // Inicia jni4net
        Bridge.setVerbose(true);
        Bridge.init();

        // Carga el .j4n.dll producido por proxygen
        File proxyAssemblyFile = new File("DirectCoupling.j4n.dll");
        Bridge.LoadAndRegisterAssemblyFrom(proxyAssemblyFile);

        // Path del proyecto del cual se desea obtener el AST
        String path = "C:\\Users\\Jasson\\OneDrive\\AVIB\\randomLib\\randomLib";

        // Llamada al método que devuelve el AST, no se puede guardar como variable porque no conozco el objeto
        // Ej: Compilation comp = Program.CreateTestCompilation(path);
        Program.CreateTestCompilation(path);
    }
}
