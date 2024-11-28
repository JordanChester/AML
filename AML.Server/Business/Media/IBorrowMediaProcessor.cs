using AML.Server.DTOs;

namespace AML.Server.Business.Media;

public interface IBorrowMediaProcessor
{
    Task Process(BorrowMediaRequest request);
}