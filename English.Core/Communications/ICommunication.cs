namespace English.Core.Communications;

public interface ICommunication
{
    Task Tell(CommunicationMethod communicationMethod);
}