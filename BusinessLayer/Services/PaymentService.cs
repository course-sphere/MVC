using BusinessLayer;
using BusinessLayer.IServices;
using BusinessLayer.Requests.Payment;
using BusinessLayer.Responses;
using BusinessLayer.Responses.Course;
using BusinessLayer.Responses.Payment;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PayOS;
using PayOS.Exceptions;
using PayOS.Models.V2.PaymentRequests;
using PayOS.Models.Webhooks;

namespace BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IClaimService _service;
        private readonly AppSettings _appSettings;

        public PaymentService(IUnitOfWork uow, IClaimService service, AppSettings appSettings)
        {
            _uow = uow;
            _service = service;
            _appSettings = appSettings;
        }


        /*public async Task<ApiResponse> CreatePaymentUrlAsync(CreateNewPaymentRequest request, HttpContext context)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var claim = _service.GetUserClaim();
                var course = await _unitOfWork.Courses.GetAsync(c => c.CourseId == request.CourseId);
                if (course == null)
                {
                    return response.SetNotFound(message: "Course not found");
                }

                var enrollment = await _unitOfWork.Enrollments.GetAsync(e => e.UserId == claim.UserId && e.CourseId == course.CourseId);

                if (enrollment == null)
                {
                    enrollment = new Enrollment
                    {
                        EnrollmentId = Guid.NewGuid(),
                        UserId = claim.UserId,
                        CourseId = course.CourseId,
                        Status = EnrollmentStatus.PendingPayment
                    };

                    await _unitOfWork.Enrollments.AddAsync(enrollment);
                }
                else
                {
                    enrollment.Status = EnrollmentStatus.PendingPayment;
                    enrollment.UpdatedAt = DateTime.UtcNow;
                }
                await _unitOfWork.SaveChangeAsync();

                var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_config["TimeZoneId"]);
                var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
                var tick = DateTime.Now.Ticks.ToString();
                var pay = new VnPayLibrary();

                var txnRef = $"{claim.UserId}|{course.CourseId}|{DateTime.UtcNow.Ticks}";

                var urlCallBack = $"{_config["PaymentCallBack:ReturnUrl"]}?userId={claim.UserId}&amount={course.Price}";

                pay.AddRequestData("vnp_Version", _config["Vnpay:Version"]);
                pay.AddRequestData("vnp_Command", _config["Vnpay:Command"]);
                pay.AddRequestData("vnp_TmnCode", _config["Vnpay:TmnCode"]);
                pay.AddRequestData("vnp_Amount", ((int)course.Price * 100 *26000).ToString());
                pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
                pay.AddRequestData("vnp_CurrCode", _config["Vnpay:CurrCode"]);
                pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
                pay.AddRequestData("vnp_Locale", _config["Vnpay:Locale"]);
                pay.AddRequestData("vnp_OrderInfo", $"{course.Price}");
                pay.AddRequestData("vnp_OrderType", "VnPay");
                pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
                pay.AddRequestData("vnp_TxnRef", txnRef);

                var paymentUrl = pay.CreateRequestUrl(_config["Vnpay:BaseUrl"], _config["Vnpay:HashSecret"]);

                return response.SetOk(paymentUrl);
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(message: ex.Message);
            }
        }

        public async Task<ApiResponse> PaymentExecuteAsync(IQueryCollection collection)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var pay = new VnPayLibrary();
                var vnPayResponse = pay.GetFullResponseData(collection, _config["Vnpay:HashSecret"]);

                if (!collection.TryGetValue("vnp_TxnRef", out var txnRefValue))
                    return response.SetBadRequest("Missing vnp_TxnRef");

                var parts = txnRefValue.ToString().Split('|');
                if (parts.Length < 2)
                    return response.SetBadRequest("Invalid TxnRef format");

                if (!Guid.TryParse(parts[0], out Guid userId))
                    return response.SetBadRequest("Invalid userId");

                if (!Guid.TryParse(parts[1], out Guid courseId))
                    return response.SetBadRequest("Invalid courseId");

                var enrollment = await _unitOfWork.Enrollments.GetAsync(e =>
                    e.UserId == userId &&
                    e.CourseId == courseId
                );

                if (enrollment == null)
                    return response.SetNotFound("Enrollment not found");

                if (enrollment.Status != EnrollmentStatus.PendingPayment)
                {
                    return response.SetOk("Payment already processed");
                }
                   
                if (vnPayResponse.VnPayResponseCode != "00")
                {
                    enrollment.Status = EnrollmentStatus.Cancelled;

                    await _unitOfWork.Payments.AddAsync(new Payment
                    {
                        PaymentId = Guid.NewGuid(),
                        UserId = userId,
                        CourseId = courseId,
                        Amount = enrollment.Course!.Price,
                        Method = "VnPay",
                    });

                    await _unitOfWork.SaveChangeAsync();
                    return response.SetBadRequest("Payment failed");
                }

                var course = await _unitOfWork.Courses.GetAsync(c => c.CourseId == enrollment.CourseId);
                if (course == null) return response.SetNotFound("Course not found");
                // 2️⃣ Tạo Payment
                var payment = new Payment
                {
                    PaymentId = Guid.NewGuid(),
                    UserId = userId,
                    CourseId = courseId,
                    Amount = course.Price,
                    Method = "VnPay",
                    IsSuccess = true,
                    EnrollmentId = enrollment.EnrollmentId
                };

                enrollment.Status = EnrollmentStatus.Active;

                await _unitOfWork.Payments.AddAsync(payment);
                await _unitOfWork.SaveChangeAsync();

                return response.SetOk("Payment created successfully ^^");
            }
            catch (Exception ex)
            {
                return response.SetBadRequest(message: ex.Message);
            }
        }*/

        public async Task<PaymentResponse> CreatePayOSPaymentAsync(CreateNewPaymentRequest request)
        {
            var userId = _service.GetUserClaim().UserId;
            var course = await _uow.Courses.GetAsync(c => c.CourseId == request.CourseId);
            var enrollment = new Enrollment
            {
                EnrollmentId = Guid.NewGuid(),
                CourseId = course.CourseId,
                UserId = userId,
                Status = EnrollmentStatus.PendingPayment,
            };
            await _uow.Enrollments.AddAsync(enrollment);
            

            /*var payOS = new PayOSClient(
                Environment.GetEnvironmentVariable(_appSettings.PayOS.ClientId),
                Environment.GetEnvironmentVariable(_appSettings.PayOS.ApiKey),
                Environment.GetEnvironmentVariable(_appSettings.PayOS.ChecksumKey)
            );*/
            var payOS = new PayOSClient(
                _appSettings.PayOS.ClientId,
                _appSettings.PayOS.ApiKey,
                _appSettings.PayOS.ChecksumKey
            );

            var requestData = new CreatePaymentLinkRequest
            {
                OrderCode = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Amount = (int)request.Amount,
                Description = $"Course: {course.Title}",
                ReturnUrl = _appSettings.PayOS.ReturnUrl,
                CancelUrl = _appSettings.PayOS.CancelUrl
            };

            var response = await payOS.PaymentRequests.CreateAsync(requestData);
            var payment = new Payment
            {
                PaymentId = Guid.NewGuid(),
                UserId = userId,
                CourseId = course.CourseId,
                EnrollmentId = enrollment.EnrollmentId,
                Amount = request.Amount,
                Status = PaymentStatus.Pending,
                OrderCode = requestData.OrderCode,
                PaymentLinkId = response.PaymentLinkId,
                CheckoutUrl = response.CheckoutUrl
            };

            await _uow.Payments.AddAsync(payment);
            await _uow.SaveChangeAsync();
            payment.CheckoutUrl = response.CheckoutUrl;
            await _uow.SaveChangeAsync();
            Console.WriteLine(response);
            return new PaymentResponse
            {
                CheckoutUrl = response.CheckoutUrl
            };
        }
        public async Task HandlePayOSWebhookAsync(WebhookData data)
        {
            var payment = await _uow.Payments
                .GetAsync(p => p.OrderCode == data.OrderCode);

            if (payment == null)
                throw new Exception("Payment not found");
            var enrollment = await _uow.Enrollments.GetAsync(e => e.EnrollmentId == payment.EnrollmentId);
            if (enrollment == null) return;
            // 🚨 CHỐNG TRÙNG WEBHOOK
            if (payment.Status == PaymentStatus.Paid)
                return;
            if (data.Code == "00")
            {
                payment.Status = PaymentStatus.Paid;
                payment.PaidAt = DateTime.UtcNow;
                payment.Reference = data.Reference;
                payment.CounterAccountNumber = data.CounterAccountNumber;
                payment.CounterAccountName = data.CounterAccountName;
                payment.CounterAccountBankName = data.CounterAccountBankName;
                enrollment.Status = EnrollmentStatus.Active;
            }
            else
            {
                payment.Status = PaymentStatus.Failed;
                enrollment.Status = EnrollmentStatus.Cancelled;
            }
            _uow.Enrollments.Update(enrollment);
            _uow.Payments.Update(payment);
            await _uow.SaveChangeAsync();
        }

    }
}
