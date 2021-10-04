using PastebinAPI.paste;

namespace PastebinAPI.paste
{
    public interface PasteBuilder
    {
        PasteBuilder SetKey(string key);
        PasteBuilder setTitle(string title);
        PasteBuilder setSize(long size);
        PasteBuilder setUserFriendlyLanguage(string language);
        PasteBuilder setMachineFriendlyLanguage(string language);
        PasteBuilder setHits(int hits);
        PasteBuilder setExpire(PasteExpire expire);
        PasteBuilder setRaw(string raw);
        PasteBuilder setVisiblity(PasteVisibility visibility);
        PasteBuilder setPublishDate(long publishDate);
        PasteBuilder setRemainingTime(long remainingTime);
        Paste Build();
    }
}
