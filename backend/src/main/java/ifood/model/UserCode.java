package ifood.model;

public class UserCode {
    private String status;
    private String userCode;
    private String authorizationCodeVerifier;
    private String verificationUrl;
    private String verificationUrlComplete;
    private long expiresIn;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getUserCode() {
        return userCode;
    }

    public void setUserCode(String userCode) {
        this.userCode = userCode;
    }

    public String getAuthorizationCodeVerifier() {
        return authorizationCodeVerifier;
    }

    public void setAuthorizationCodeVerifier(String authorizationCodeVerifier) {
        this.authorizationCodeVerifier = authorizationCodeVerifier;
    }

    public void setExpiresIn(long expiresIn) {
        this.expiresIn = expiresIn;
    }

    public long getExpiresIn() {
        return expiresIn;
    }

    @Override
    public String toString() {
        return "UserCode{" +
                "userCode='" + userCode + '\'' +
                ", authorizationCodeVerifier='" + authorizationCodeVerifier + '\'' +
                ", verificationUrl='" + verificationUrl + '\'' +
                ", verificationUrlComplete='" + verificationUrlComplete + '\'' +
                ", expiresIn=" + expiresIn +
                '}';
    }
}
