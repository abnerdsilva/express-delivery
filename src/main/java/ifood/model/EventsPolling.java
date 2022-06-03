package ifood.model;

public class EventsPolling {
    private String createdAt;
    private String fullCode;
    private String code;
    private String orderId;
    private String id;
    private Metadata metadata;
    private EventsPollingError error;

    public EventsPolling() {
    }

    public String getCreatedAt() {
        return createdAt;
    }

    public void setCreatedAt(String createdAt) {
        this.createdAt = createdAt;
    }

    public String getFullCode() {
        return fullCode;
    }

    public void setFullCode(String fullCode) {
        this.fullCode = fullCode;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Metadata getMetadata() {
        return metadata;
    }

    public void setMetadata(Metadata metadata) {
        this.metadata = metadata;
    }

    public EventsPollingError getError() {
        return error;
    }

    public void setError(EventsPollingError error) {
        this.error = error;
    }

    @Override
    public String toString() {
        return "EventsPolling{" +
                "createdAt='" + createdAt + '\'' +
                ", fullCode='" + fullCode + '\'' +
                ", code='" + code + '\'' +
                ", orderId='" + orderId + '\'' +
                ", id='" + id + '\'' +
                ", metadata=" + metadata +
                ", error=" + error +
                '}';
    }

    private static class Metadata {
        private String cancelStage;
        private String origin;
        private boolean timeoutEvent;
        private String cancelOrigin;
        private String cancelReason;
        private String cancelUser;
        private String cancellationRequestEventId;
        private CancellationDispute cancellationDispute;
        private CancellationOccurrence cancellationOccurrence;

        public String getCancelStage() {
            return cancelStage;
        }

        public void setCancelStage(String cancelStage) {
            this.cancelStage = cancelStage;
        }

        public String getOrigin() {
            return origin;
        }

        public void setOrigin(String origin) {
            this.origin = origin;
        }

        public boolean isTimeoutEvent() {
            return timeoutEvent;
        }

        public void setTimeoutEvent(boolean timeoutEvent) {
            this.timeoutEvent = timeoutEvent;
        }

        public String getCancelOrigin() {
            return cancelOrigin;
        }

        public void setCancelOrigin(String cancelOrigin) {
            this.cancelOrigin = cancelOrigin;
        }

        public String getCancelReason() {
            return cancelReason;
        }

        public void setCancelReason(String cancelReason) {
            this.cancelReason = cancelReason;
        }

        public String getCancelUser() {
            return cancelUser;
        }

        public void setCancelUser(String cancelUser) {
            this.cancelUser = cancelUser;
        }

        public String getCancellationRequestEventId() {
            return cancellationRequestEventId;
        }

        public void setCancellationRequestEventId(String cancellationRequestEventId) {
            this.cancellationRequestEventId = cancellationRequestEventId;
        }

        public CancellationDispute getCancellationDispute() {
            return cancellationDispute;
        }

        public void setCancellationDispute(CancellationDispute cancellationDispute) {
            this.cancellationDispute = cancellationDispute;
        }

        public CancellationOccurrence getCancellationOccurrence() {
            return cancellationOccurrence;
        }

        public void setCancellationOccurrence(CancellationOccurrence cancellationOccurrence) {
            this.cancellationOccurrence = cancellationOccurrence;
        }

        public Metadata() {
        }
    }

    private static class CancellationDispute {
        private String isContestable;
        private String reason;

        public String getIsContestable() {
            return isContestable;
        }

        public void setIsContestable(String isContestable) {
            this.isContestable = isContestable;
        }

        public String getReason() {
            return reason;
        }

        public void setReason(String reason) {
            this.reason = reason;
        }

        public CancellationDispute() {
        }
    }

    private static class CancellationOccurrence {
        private CancellationOccurrenceRestaurant restaurant;
        private CancellationOccurrenceConsumer consumer;
        private CancellationOccurrenceLogistic logistic;

        public CancellationOccurrence() {
        }

        public CancellationOccurrenceRestaurant getRestaurant() {
            return restaurant;
        }

        public void setRestaurant(CancellationOccurrenceRestaurant restaurant) {
            this.restaurant = restaurant;
        }

        public CancellationOccurrenceConsumer getConsumer() {
            return consumer;
        }

        public void setConsumer(CancellationOccurrenceConsumer consumer) {
            this.consumer = consumer;
        }

        public CancellationOccurrenceLogistic getLogistic() {
            return logistic;
        }

        public void setLogistic(CancellationOccurrenceLogistic logistic) {
            this.logistic = logistic;
        }
    }

    private static class CancellationOccurrenceRestaurant {
        private String financialOccurrence;
        private String paymentType;

        public CancellationOccurrenceRestaurant() {
        }

        public String getFinancialOccurrence() {
            return financialOccurrence;
        }

        public void setFinancialOccurrence(String financialOccurrence) {
            this.financialOccurrence = financialOccurrence;
        }

        public String getPaymentType() {
            return paymentType;
        }

        public void setPaymentType(String paymentType) {
            this.paymentType = paymentType;
        }
    }

    private static class CancellationOccurrenceConsumer {
        private String financialOccurrence;
        private String paymentType;


        public CancellationOccurrenceConsumer() {
        }

        public String getFinancialOccurrence() {
            return financialOccurrence;
        }

        public void setFinancialOccurrence(String financialOccurrence) {
            this.financialOccurrence = financialOccurrence;
        }

        public String getPaymentType() {
            return paymentType;
        }

        public void setPaymentType(String paymentType) {
            this.paymentType = paymentType;
        }
    }

    private static class CancellationOccurrenceLogistic {
        private String financialOccurrence;
        private String paymentType;

        public CancellationOccurrenceLogistic() {
        }

        public String getFinancialOccurrence() {
            return financialOccurrence;
        }

        public void setFinancialOccurrence(String financialOccurrence) {
            this.financialOccurrence = financialOccurrence;
        }

        public String getPaymentType() {
            return paymentType;
        }

        public void setPaymentType(String paymentType) {
            this.paymentType = paymentType;
        }
    }

    private static class EventsPollingError {
        private String error;
        private String errorDescription;
        private String code;
        private String name;
        private String field;
        private String details;
        private String message;

        public EventsPollingError() {
        }

        public String getError() {
            return error;
        }

        public void setError(String error) {
            this.error = error;
        }

        public String getErrorDescription() {
            return errorDescription;
        }

        public void setErrorDescription(String errorDescription) {
            this.errorDescription = errorDescription;
        }

        public String getCode() {
            return code;
        }

        public void setCode(String code) {
            this.code = code;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getField() {
            return field;
        }

        public void setField(String field) {
            this.field = field;
        }

        public String getDetails() {
            return details;
        }

        public void setDetails(String details) {
            this.details = details;
        }

        public String getMessage() {
            return message;
        }

        public void setMessage(String message) {
            this.message = message;
        }
    }
}