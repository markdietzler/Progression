using PastebinAPI.paste;
using System;

namespace PastebinAPI.user.internal_user
{
    public interface UserBuilder {
        UserBuilder SetUserName( String userName);
        UserBuilder setWebsite( String website);
        UserBuilder SetEmail( String email);
        UserBuilder SetAccountType( AccountType accountType);
        UserBuilder SetLocation( String location);
        UserBuilder SetDefaultPasteLanguage( String defaultPasteLanguage);
        UserBuilder SetDefaultPasteExpiration(PasteExpire defaultPasteExpiration);
        UserBuilder SetDefaultPasteVisibility(PasteVisibility defaultPasteVisibility);
        User Build();
    }
}
