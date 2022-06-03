package ifood.model;

import java.util.List;

public class Order {
    private String id;
    private OrderDelivery delivery;
    private OrderTakeout takeout;
    private OrderIndoor indoor;
    private OrderSchedule schedule;
    private String orderType;
    private String orderTiming;
    private String displayId;
    private String createdAt;
    private String preparationStartDateTime;
    private boolean isTest;
    private OrderMerchant merchant;
    private OrderCustomer customer;
    private List<OrderItems> items;
    private String salesChannel;
    private OrderTotal total;
    private OrderPayments payments;
    private List<OrderBenefits> benefits;
    private String extraInfo;
    private String observations;
    private List<OrderAdditionalFees> additionalFees;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public OrderDelivery getDelivery() {
        return delivery;
    }

    public void setDelivery(OrderDelivery delivery) {
        this.delivery = delivery;
    }

    public OrderTakeout getTakeout() {
        return takeout;
    }

    public void setTakeout(OrderTakeout takeout) {
        this.takeout = takeout;
    }

    public OrderIndoor getIndoor() {
        return indoor;
    }

    public void setIndoor(OrderIndoor indoor) {
        this.indoor = indoor;
    }

    public OrderSchedule getSchedule() {
        return schedule;
    }

    public void setSchedule(OrderSchedule schedule) {
        this.schedule = schedule;
    }

    public String getOrderType() {
        return orderType;
    }

    public void setOrderType(String orderType) {
        this.orderType = orderType;
    }

    public String getOrderTiming() {
        return orderTiming;
    }

    public void setOrderTiming(String orderTiming) {
        this.orderTiming = orderTiming;
    }

    public String getDisplayId() {
        return displayId;
    }

    public void setDisplayId(String displayId) {
        this.displayId = displayId;
    }

    public String getCreatedAt() {
        return createdAt;
    }

    public void setCreatedAt(String createdAt) {
        this.createdAt = createdAt;
    }

    public String getPreparationStartDateTime() {
        return preparationStartDateTime;
    }

    public void setPreparationStartDateTime(String preparationStartDateTime) {
        this.preparationStartDateTime = preparationStartDateTime;
    }

    public boolean isTest() {
        return isTest;
    }

    public void setTest(boolean test) {
        isTest = test;
    }

    public OrderMerchant getMerchant() {
        return merchant;
    }

    public void setMerchant(OrderMerchant merchant) {
        this.merchant = merchant;
    }

    public OrderCustomer getCustomer() {
        return customer;
    }

    public void setCustomer(OrderCustomer customer) {
        this.customer = customer;
    }

    public List<OrderItems> getItems() {
        return items;
    }

    public void setItems(List<OrderItems> items) {
        this.items = items;
    }

    public String getSalesChannel() {
        return salesChannel;
    }

    public void setSalesChannel(String salesChannel) {
        this.salesChannel = salesChannel;
    }

    public OrderTotal getTotal() {
        return total;
    }

    public void setTotal(OrderTotal total) {
        this.total = total;
    }

    public OrderPayments getPayments() {
        return payments;
    }

    public void setPayments(OrderPayments payments) {
        this.payments = payments;
    }

    public List<OrderBenefits> getBenefits() {
        return benefits;
    }

    public void setBenefits(List<OrderBenefits> benefits) {
        this.benefits = benefits;
    }

    public String getExtraInfo() {
        return extraInfo;
    }

    public void setExtraInfo(String extraInfo) {
        this.extraInfo = extraInfo;
    }

    public String getObservations() {
        return observations;
    }

    public void setObservations(String observations) {
        this.observations = observations;
    }

    public List<OrderAdditionalFees> getAdditionalFees() {
        return additionalFees;
    }

    public void setAdditionalFees(List<OrderAdditionalFees> additionalFees) {
        this.additionalFees = additionalFees;
    }

    public class OrderDelivery {
        private String mode;
        private String deliveredBy;
        private String observations;
        private String deliveryDateTime;
        private OrderDeliveryAddress deliveryAddress;

        public String getMode() {
            return mode;
        }

        public void setMode(String mode) {
            this.mode = mode;
        }

        public String getDeliveredBy() {
            return deliveredBy;
        }

        public void setDeliveredBy(String deliveredBy) {
            this.deliveredBy = deliveredBy;
        }

        public String getObservations() {
            return observations;
        }

        public void setObservations(String observations) {
            this.observations = observations;
        }

        public String getDeliveryDateTime() {
            return deliveryDateTime;
        }

        public void setDeliveryDateTime(String deliveryDateTime) {
            this.deliveryDateTime = deliveryDateTime;
        }

        public OrderDeliveryAddress getDeliveryAddress() {
            return deliveryAddress;
        }

        public void setDeliveryAddress(OrderDeliveryAddress deliveryAddress) {
            this.deliveryAddress = deliveryAddress;
        }

        @Override
        public String toString() {
            return "OrderDelivery{" +
                    "mode='" + mode + '\'' +
                    ", deliveredBy='" + deliveredBy + '\'' +
                    ", observations='" + observations + '\'' +
                    ", deliveryDateTime='" + deliveryDateTime + '\'' +
                    ", deliveryAddress=" + deliveryAddress.toString() +
                    '}';
        }

        public class OrderDeliveryAddress {
            private String streetName;
            private String streeNumber;
            private String formattedAddress;
            private String neighborhood;
            private String postalCode;
            private String city;
            private String state;
            private String country;
            private String reference;
            private String complement;
            private OrderDeliveryAddressCoordinates coordinates;

            public String getStreetName() {
                return streetName;
            }

            public void setStreetName(String streetName) {
                this.streetName = streetName;
            }

            public String getStreeNumber() {
                return streeNumber;
            }

            public void setStreeNumber(String streeNumber) {
                this.streeNumber = streeNumber;
            }

            public String getFormattedAddress() {
                return formattedAddress;
            }

            public void setFormattedAddress(String formattedAddress) {
                this.formattedAddress = formattedAddress;
            }

            public String getNeighborhood() {
                return neighborhood;
            }

            public void setNeighborhood(String neighborhood) {
                this.neighborhood = neighborhood;
            }

            public String getPostalCode() {
                return postalCode;
            }

            public void setPostalCode(String postalCode) {
                this.postalCode = postalCode;
            }

            public String getCity() {
                return city;
            }

            public void setCity(String city) {
                this.city = city;
            }

            public String getState() {
                return state;
            }

            public void setState(String state) {
                this.state = state;
            }

            public String getCountry() {
                return country;
            }

            public void setCountry(String country) {
                this.country = country;
            }

            public String getReference() {
                return reference;
            }

            public void setReference(String reference) {
                this.reference = reference;
            }

            public String getComplement() {
                return complement;
            }

            public void setComplement(String complement) {
                this.complement = complement;
            }

            public OrderDeliveryAddressCoordinates getCoordinates() {
                return coordinates;
            }

            public void setCoordinates(OrderDeliveryAddressCoordinates coordinates) {
                this.coordinates = coordinates;
            }

            @Override
            public String toString() {
                return "OrderDeliveryAddress{" +
                        "streetName='" + streetName + '\'' +
                        ", streeNumber='" + streeNumber + '\'' +
                        ", formattedAddress='" + formattedAddress + '\'' +
                        ", neighborhood='" + neighborhood + '\'' +
                        ", postalCode='" + postalCode + '\'' +
                        ", city='" + city + '\'' +
                        ", state='" + state + '\'' +
                        ", country='" + country + '\'' +
                        ", reference='" + reference + '\'' +
                        ", complement='" + complement + '\'' +
                        ", coordinates=" + coordinates.toString() +
                        '}';
            }

            private class OrderDeliveryAddressCoordinates {
                private double latitude;
                private double logintude;

                @Override
                public String toString() {
                    return "OrderDeliveryAddressCoordinates{" +
                            "latitude=" + latitude +
                            ", logintude=" + logintude +
                            '}';
                }
            }
        }
    }

    private class OrderTakeout {
        private String mode;
        private String takeoutDateTime;
    }

    private class OrderIndoor {
        private String mode;
        private String table;
        private String deliveryDateTime;
    }

    private class OrderSchedule {
        private String deliveryDateTimeStart;
        private String deliveryDateTimeEnd;
    }

    private class OrderMerchant {
        private String id;
        private String name;

        @Override
        public String toString() {
            return "OrderMerchant{" +
                    "id='" + id + '\'' +
                    ", name='" + name + '\'' +
                    '}';
        }
    }

    public class OrderCustomer {
        private String id;
        private String name;
        private String documentNumber;
        private OrderCustomerPhone phone;
        private int ordersCountOnMerchant;

        public String getId() {
            return id;
        }

        public void setId(String id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getDocumentNumber() {
            return documentNumber;
        }

        public void setDocumentNumber(String documentNumber) {
            this.documentNumber = documentNumber;
        }

        public OrderCustomerPhone getPhone() {
            return phone;
        }

        public void setPhone(OrderCustomerPhone phone) {
            this.phone = phone;
        }

        public int getOrdersCountOnMerchant() {
            return ordersCountOnMerchant;
        }

        public void setOrdersCountOnMerchant(int ordersCountOnMerchant) {
            this.ordersCountOnMerchant = ordersCountOnMerchant;
        }

        @Override
        public String toString() {
            return "OrderCustomer{" +
                    "id='" + id + '\'' +
                    ", name='" + name + '\'' +
                    ", documentNumber='" + documentNumber + '\'' +
                    ", phone=" + phone +
                    ", ordersCountOnMerchant=" + ordersCountOnMerchant +
                    '}';
        }

        public class OrderCustomerPhone {
            private String number;
            private String localizer;
            private String localizerExpiration;

            public String getNumber() {
                return number;
            }

            public void setNumber(String number) {
                this.number = number;
            }

            public String getLocalizer() {
                return localizer;
            }

            public void setLocalizer(String localizer) {
                this.localizer = localizer;
            }

            public String getLocalizerExpiration() {
                return localizerExpiration;
            }

            public void setLocalizerExpiration(String localizerExpiration) {
                this.localizerExpiration = localizerExpiration;
            }

            @Override
            public String toString() {
                return "OrderCustomerPhone{" +
                        "number='" + number + '\'' +
                        ", localizer='" + localizer + '\'' +
                        ", localizerExpiration='" + localizerExpiration + '\'' +
                        '}';
            }
        }
    }

    public class OrderItems {
        private int index;
        private String id;
        private String name;
        private String unit;
        private int quantity;
        private double unitPrice;
        private double optionsPrice;
        private String externalCode;
        private String observations;
        private double totalPrice;
        private List<OrderItemsOptions> options;
        private double price;

        public int getIndex() {
            return index;
        }

        public void setIndex(int index) {
            this.index = index;
        }

        public String getId() {
            return id;
        }

        public void setId(String id) {
            this.id = id;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getUnit() {
            return unit;
        }

        public void setUnit(String unit) {
            this.unit = unit;
        }

        public int getQuantity() {
            return quantity;
        }

        public void setQuantity(int quantity) {
            this.quantity = quantity;
        }

        public double getUnitPrice() {
            return unitPrice;
        }

        public void setUnitPrice(double unitPrice) {
            this.unitPrice = unitPrice;
        }

        public double getOptionsPrice() {
            return optionsPrice;
        }

        public void setOptionsPrice(double optionsPrice) {
            this.optionsPrice = optionsPrice;
        }

        public String getExternalCode() {
            return externalCode;
        }

        public void setExternalCode(String externalCode) {
            this.externalCode = externalCode;
        }

        public String getObservations() {
            return observations;
        }

        public void setObservations(String observations) {
            this.observations = observations;
        }

        public double getTotalPrice() {
            return totalPrice;
        }

        public void setTotalPrice(double totalPrice) {
            this.totalPrice = totalPrice;
        }

        public List<OrderItemsOptions> getOptions() {
            return options;
        }

        public void setOptions(List<OrderItemsOptions> options) {
            this.options = options;
        }

        public double getPrice() {
            return price;
        }

        public void setPrice(double price) {
            this.price = price;
        }

        public class OrderItemsOptions {
            private int index;
            private String id;
            private String name;
            private String unit;
            private int quantity;
            private double unitPrice;
            private double addition;
            private String externalCode;
            private double price;

            public int getIndex() {
                return index;
            }

            public void setIndex(int index) {
                this.index = index;
            }

            public String getId() {
                return id;
            }

            public void setId(String id) {
                this.id = id;
            }

            public String getName() {
                return name;
            }

            public void setName(String name) {
                this.name = name;
            }

            public String getUnit() {
                return unit;
            }

            public void setUnit(String unit) {
                this.unit = unit;
            }

            public int getQuantity() {
                return quantity;
            }

            public void setQuantity(int quantity) {
                this.quantity = quantity;
            }

            public double getUnitPrice() {
                return unitPrice;
            }

            public void setUnitPrice(double unitPrice) {
                this.unitPrice = unitPrice;
            }

            public double getAddition() {
                return addition;
            }

            public void setAddition(double addition) {
                this.addition = addition;
            }

            public String getExternalCode() {
                return externalCode;
            }

            public void setExternalCode(String externalCode) {
                this.externalCode = externalCode;
            }

            public double getPrice() {
                return price;
            }

            public void setPrice(double price) {
                this.price = price;
            }
        }
    }

    public class OrderTotal {
        private double subTotal;
        private double deliveryFee;
        private double benefits;
        private double orderAmount;
        private double additionalFees;

        public double getSubTotal() {
            return subTotal;
        }

        public void setSubTotal(double subTotal) {
            this.subTotal = subTotal;
        }

        public double getDeliveryFee() {
            return deliveryFee;
        }

        public void setDeliveryFee(double deliveryFee) {
            this.deliveryFee = deliveryFee;
        }

        public double getBenefits() {
            return benefits;
        }

        public void setBenefits(double benefits) {
            this.benefits = benefits;
        }

        public double getOrderAmount() {
            return orderAmount;
        }

        public void setOrderAmount(double orderAmount) {
            this.orderAmount = orderAmount;
        }

        public double getAdditionalFees() {
            return additionalFees;
        }

        public void setAdditionalFees(double additionalFees) {
            this.additionalFees = additionalFees;
        }
    }

    public class OrderPayments {
        private double prepaid;
        private double pending;
        private List<OrderPaymentsMethods> methods;

        public double getPrepaid() {
            return prepaid;
        }

        public void setPrepaid(double prepaid) {
            this.prepaid = prepaid;
        }

        public double getPending() {
            return pending;
        }

        public void setPending(double pending) {
            this.pending = pending;
        }

        public List<OrderPaymentsMethods> getMethods() {
            return methods;
        }

        public void setMethods(List<OrderPaymentsMethods> methods) {
            this.methods = methods;
        }

        public class OrderPaymentsMethods {
            private double value;
            private String currency;
            private String method;
            private String type;
            private OrderPaymentsMethodsCash cash;
            private OrderPaymentsMethodsCard card;
            private boolean prepaid;

            public double getValue() {
                return value;
            }

            public void setValue(double value) {
                this.value = value;
            }

            public String getCurrency() {
                return currency;
            }

            public void setCurrency(String currency) {
                this.currency = currency;
            }

            public String getMethod() {
                return method;
            }

            public void setMethod(String method) {
                this.method = method;
            }

            public String getType() {
                return type;
            }

            public void setType(String type) {
                this.type = type;
            }

            public OrderPaymentsMethodsCash getCash() {
                return cash;
            }

            public void setCash(OrderPaymentsMethodsCash cash) {
                this.cash = cash;
            }

            public OrderPaymentsMethodsCard getCard() {
                return card;
            }

            public void setCard(OrderPaymentsMethodsCard card) {
                this.card = card;
            }

            public boolean isPrepaid() {
                return prepaid;
            }

            public void setPrepaid(boolean prepaid) {
                this.prepaid = prepaid;
            }

            public class OrderPaymentsMethodsCash {
                private double changeFor;

                public double getChangeFor() {
                    return changeFor;
                }

                public void setChangeFor(double changeFor) {
                    this.changeFor = changeFor;
                }
            }

            public class OrderPaymentsMethodsCard {
                private String brand;

                public String getBrand() {
                    return brand;
                }

                public void setBrand(String brand) {
                    this.brand = brand;
                }
            }
        }
    }

    private class OrderBenefits {
        private double value;
        private List<OrderSponsorshipValues> sponsorshipValues;
        private String target;
        private String targetId;

        private class OrderSponsorshipValues {
            private String name;
            private double value;
        }
    }

    private class OrderAdditionalFees {
        private List<OrderAdditionalFeesValues> fees;

        private class OrderAdditionalFeesValues {
            private String type;
            private String value;
        }
    }

    @Override
    public String toString() {
        return "Order{" +
                "id='" + id + '\'' +
                ", delivery=" + delivery.toString() +
                ", orderType='" + orderType + '\'' +
                ", orderTiming='" + orderTiming + '\'' +
                ", displayId='" + displayId + '\'' +
                ", createdAt='" + createdAt + '\'' +
                ", preparationStartDateTime='" + preparationStartDateTime + '\'' +
                ", isTest=" + isTest +
                ", merchant=" + merchant.toString() +
                ", customer=" + customer.toString() +
                ", items=" + items.toString() +
                ", salesChannel='" + salesChannel + '\'' +
                ", total=" + total.toString() +
                ", payments=" + payments.toString() +
                ", extraInfo='" + extraInfo + '\'' +
                ", observations='" + observations + '\'' +
                '}';
    }
}
