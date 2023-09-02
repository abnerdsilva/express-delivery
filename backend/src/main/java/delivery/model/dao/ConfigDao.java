package delivery.model.dao;

public class ConfigDao {
    private String codConfiguracao;
    private String item;
    private String flag1;
    private String flag2;
    private String flag3;
    private String flag4;
    private String flag5;

    public ConfigDao() {
    }

    public void setCodConfiguracao(String codConfiguracao) {
        this.codConfiguracao = codConfiguracao;
    }

    public String getCodConfiguracao() {
        return codConfiguracao;
    }

    public void setItem(String item) {
        this.item = item;
    }

    public String getItem() {
        return item;
    }

    public void setFlag1(String flag1) {
        this.flag1 = flag1;
    }

    public String getFlag1() {
        return flag1;
    }

    public void setFlag2(String flag2) {
        this.flag2 = flag2;
    }

    public String getFlag2() {
        return flag2;
    }

    public void setFlag3(String flag3) {
        this.flag3 = flag3;
    }

    public String getFlag3() {
        return flag3;
    }

    public void setFlag4(String flag4) {
        this.flag4 = flag4;
    }

    public String getFlag4() {
        return flag4;
    }

    public void setFlag5(String flag5) {
        this.flag5 = flag5;
    }

    public String getFlag5() {
        return flag5;
    }

    @Override
    public String toString() {
        return "Config{" +
                "codConfiguracao=" + codConfiguracao +
                ", item='" + item + '\'' +
                ", flag1='" + flag1 + '\'' +
                ", flag2='" + flag2 + '\'' +
                ", flag3='" + flag3 + '\'' +
                ", flag4='" + flag4 + '\'' +
                ", flag5='" + flag5 + '\'' +
                '}';
    }
}
