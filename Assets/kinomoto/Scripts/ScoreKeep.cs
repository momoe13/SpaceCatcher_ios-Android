
using UnityEditor;

public static class ScoreKeep
{
    public static int score;//��{�X�R�A

    public static int sterScore;//�X�^�[�擾���̕ϐ�

    public static int basePowerUpScore;//��b�p���[�A�b�v�A�C�e���擾���̕ϐ�

    public static int ratePowerUpScore;//�{���p���[�A�b�v�A�C�e���擾���̕ϐ�

    public static int widthPowerUpScore;//�����p���[�A�b�v�A�C�e���擾���̕ϐ�

    public static int turnRecoveryUpScore;//�^�[���񕜃A�C�e���擾���̕ϐ�

    public static int prizeScore;//�i�i�A�C�e���l�����̕ϐ�

    public static void AllValueReset()
    {
        score = 0;
        sterScore = 0;
        basePowerUpScore = 0;
        ratePowerUpScore = 0;
        widthPowerUpScore = 0;
        turnRecoveryUpScore = 0;
        prizeScore = 0;
    }
}
