package org.REST.Service;


public interface MailService {
    Boolean send_mail(String to_email, String subject, String body);
}