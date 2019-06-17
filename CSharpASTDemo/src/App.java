import net.sf.jni4net.Bridge;
import directcoupling.Program;

import java.io.File;

public class App {
    public static void main(String[] args) throws Exception{
        Bridge.setVerbose(true);
        Bridge.init();

        File proxyAssemblyFile = new File("DirectCoupling.j4n.dll");

        Bridge.LoadAndRegisterAssemblyFrom(proxyAssemblyFile);
        String path = "C:\\Users\\Jasson\\OneDrive\\AVIB\\randomLib\\randomLib";
        Program.CreateTestCompilation(path);
    }
}
