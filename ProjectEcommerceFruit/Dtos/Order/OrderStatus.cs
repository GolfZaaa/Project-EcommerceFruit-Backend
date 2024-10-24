namespace ProjectEcommerceFruit.Dtos.Order
{
    public enum OrderStatus
    {
        WaitingForPayment, // รอการชำระเงิน
        PendingApproval, // รอการอนุมัติจากแอดมิน
        SuccessfulPayment, // ชำระเงินสำเร็จ
        SuccessfulPaymentforcreditCard, // ชำระเงินสำเร็จสำหรับเคดิตการ์ด
        Refunded, // คืนเงิน
        Cancel, // ยกเลิก
    }
}
