package UtilLib;

public abstract class AbsCodec<T> {
    public abstract String serialize(T root);
    public abstract T deserialize(String data);
}
