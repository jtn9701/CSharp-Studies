interface ICrop
{
    string CropName;
    float WateringThreshold;
    int BaseWateringTimeMinuntes;
    float GallonsPerSqFtPerMinute;
    abstract bool NeedsFertigation(Zone zone);
}