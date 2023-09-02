package imprime;

import log.LoggerInFile;

import javax.print.*;
import javax.print.attribute.HashPrintRequestAttributeSet;
import javax.print.attribute.PrintRequestAttributeSet;
import javax.print.attribute.standard.JobName;
import javax.print.attribute.standard.MediaSizeName;
import javax.print.attribute.standard.OrientationRequested;
import java.io.ByteArrayInputStream;
import java.io.InputStream;

public class Impressora {
    private static String msgErroSemImpressora = "Nennhuma impressora foi encontrada. \r\nInstale uma\r\n impressora padrão \r\n\n\n\n\n\n\n" +
            "(Generic Text Only) e reinicie o programa.";
    private static PrintService impressora;

    /**
     * Construtor
     */
    public Impressora() {
    }

    /**
     * O metodo verifica se existe a impressora conectada e a define como padrão
     */
    public void detectaImpressoras() {
        try {
            DocFlavor df = DocFlavor.SERVICE_FORMATTED.PRINTABLE;
//            impressora = PrintServiceLookup.lookupDefaultPrintService();
            PrintService[] ps = PrintServiceLookup.lookupPrintServices(df, null);
            for (PrintService p : ps) {
                if (p.getName() != null && p.getName().contains("PRINTCOM3")) {
                    System.out.println("Impressora Selecionada: " + p.getName());
                    System.out.println("Impressora encontrada: " + p.getName());
                    impressora = p;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }
    }

    /**
     * Imprime texto informado
     *
     * @param texto - dados passados para impressão
     * @throws PrintException - exceção de impressão quando ocorre erro
     */
    public synchronized boolean imprime(String texto) throws PrintException {
        if (impressora == null) {
            System.out.println(msgErroSemImpressora);
        } else {
            InputStream stream = new ByteArrayInputStream(texto.getBytes());
            DocFlavor flavor = DocFlavor.INPUT_STREAM.AUTOSENSE;
            SimpleDoc doc = new SimpleDoc(stream, flavor, null);

            PrintRequestAttributeSet printerAttributes = new HashPrintRequestAttributeSet();
            printerAttributes.add(new JobName("Impressão", null));
            printerAttributes.add(OrientationRequested.PORTRAIT);
            printerAttributes.add(MediaSizeName.ISO_A4);

            DocPrintJob dpj = impressora.createPrintJob().getPrintService().createPrintJob();
            dpj.print(doc, printerAttributes);
            return true;
        }
        return false;
    }

    /**
     * Imprime texto informado
     * Informa se impressora não existe e avisa ao usuario
     *
     * @param bytes - texto para impressão em formato de byte[]
     * @return - status da impressão
     */
    public synchronized boolean imprime(byte[] bytes) {
        if (impressora == null) {
            System.out.println(msgErroSemImpressora);
        } else {
            System.out.println(bytes);
            try {
                DocPrintJob dpj = impressora.createPrintJob();
                InputStream stream = new ByteArrayInputStream(bytes);
                DocFlavor flavor = DocFlavor.INPUT_STREAM.AUTOSENSE;
                Doc doc = new SimpleDoc(stream, flavor, null);
                dpj.print(doc, null);
                return true;
            } catch (PrintException e) {
                e.printStackTrace();
                LoggerInFile.printError(e.getMessage());
            }
        }
        return false;
    }

    /**
     * preenche linha com caracteres, com tamanho e posição de alinhamento informado e espaço em branco
     * ou retirada de caracteres
     *
     * @param sequencia - texto que será preenchido
     * @param txtSub    - texto que deseja preencher os espaços em branco
     * @param tamanho   - tamanho maximo de caracteres
     * @param posicao   - posição de alinhamento
     * @return - retorna texto com preenchimento ou retirada de caracteres
     */
    public String preencheLinha(String sequencia, String txtSub, long tamanho, String posicao) {
        StringBuilder caracteresPreenchidos = new StringBuilder();
        String novoTexto = "";
        long qtdePreenchida = 0;

        qtdePreenchida = tamanho - sequencia.length();

        for (int i = 0; i < qtdePreenchida; i++) {
            caracteresPreenchidos.append(txtSub);
        }

        if (posicao.equals("E")) novoTexto = sequencia + caracteresPreenchidos;
        if (posicao.equals("D")) novoTexto = caracteresPreenchidos + sequencia;
        if (posicao.equals("ED") || posicao.equals("EDB"))
            novoTexto = caracteresPreenchidos.substring(0, caracteresPreenchidos.length() / 2 - 2) + " " + sequencia + " " +
                    caracteresPreenchidos.substring(caracteresPreenchidos.length() / 2 + 1);
        if (posicao.equals("EDB") || posicao.equals("M"))
            novoTexto = novoTexto.replaceAll("-", " ");


//        int maxCharRow = 60;
//        int countTxt = txt.length();
//        int middle = countTxt / 2;
//        StringBuilder txtAdd = new StringBuilder();
//        for (int i = 1; i < maxCharRow - countTxt; i++) {
//            if (i < (maxCharRow - countTxt) - middle) {
//                txtAdd.append(type);
//            } else if (i == (maxCharRow - countTxt) - middle) {
//                txtAdd.append(txt);
//            } else {
//                txtAdd.append(type);
//            }
//        }

        return novoTexto.toString();
    }
}