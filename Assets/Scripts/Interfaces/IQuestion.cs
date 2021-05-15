using SimpleJSON;

public interface IQuestion
    { 
        void Initialize(JSONNode Question);

        bool CheckCorrect();
    }