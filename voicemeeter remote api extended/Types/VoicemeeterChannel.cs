﻿namespace AtgDev.Voicemeeter.Types
{
    /// <summary>
    ///     <para>Index numbers of names:</para>
    ///     L - 0<br/>
    ///     R - 1<br/>
    ///     C - 2<br/>
    ///     LFE - 3<br/>
    ///     SL - 4<br/>
    ///     SR - 5<br/>
    ///     BL - 6<br/>
    ///     BR - 7<br/>
    /// </summary>
    enum VoicemeeterChannel
    {
        // Voicemeeter
        Strip1L = 0,
        Strip1R,

        Strip2L,
        Strip2R,
        // VIRTUAL INPUTS
        StandardVirtInL,
        StandardVirtInR,
        StandardVirtInC,
        StandardVirtInLFE,
        StandardVirtInSL,
        StandardVirtInSR,
        StandardVirtInBL,
        StandardVirtInBR,
        // HARDWARE OUTPUTS
        StandardOutA1L = 0,
        StandardOutA1R,
        StandardOutA1C,
        StandardOutA1LFE,
        StandardOutA1SL,
        StandardOutA1SR,
        StandardOutA1BL,
        StandardOutA1BR,
        // VIRTUAL OUTPUTS
        StandardVirtOutL,
        StandardVirtOutR,
        StandardVirtOutC,
        StandardVirtOutLFE,
        StandardVirtOutSL,
        StandardVirtOutSR,
        StandardVirtOutBL,
        StandardVirtOutBR,

        // Banana
        Strip3L = 4,
        Strip3R,
        // VIRTUAL INPUTS
        BananaVirt1InL,
        BananaVirt1InR,
        BananaVirt1InC,
        BananaVirt1InLFE,
        BananaVirt1InSL,
        BananaVirt1InSR,
        BananaVirt1InBL,
        BananaVirt1InBR,

        BananaVirt2InL,
        BananaVirt2InR,
        BananaVirt2InC,
        BananaVirt2InLFE,
        BananaVirt2InSL,
        BananaVirt2InSR,
        BananaVirt2InBL,
        BananaVirt2InBR,
        // HARDWARE OUTPUTS
        BananaOutA1L = 0,
        BananaOutA1R,
        BananaOutA1C,
        BananaOutA1LFE,
        BananaOutA1SL,
        BananaOutA1SR,
        BananaOutA1BL,
        BananaOutA1BR,

        BananaOutA2L,
        BananaOutA2R,
        BananaOutA2C,
        BananaOutA2LFE,
        BananaOutA2SL,
        BananaOutA2SR,
        BananaOutA2BL,
        BananaOutA2BR,

        BananaOutA3L,
        BananaOutA3R,
        BananaOutA3C,
        BananaOutA3LFE,
        BananaOutA3SL,
        BananaOutA3SR,
        BananaOutA3BL,
        BananaOutA3BR,
        // VIRTUAL OUTPUTS
        BananaVirtOutB1L,
        BananaVirtOutB1R,
        BananaVirtOutB1C,
        BananaVirtOutB1LFE,
        BananaVirtOutB1SL,
        BananaVirtOutB1SR,
        BananaVirtOutB1BL,
        BananaVirtOutB1BR,

        BananaVirtOutB2L,
        BananaVirtOutB2R,
        BananaVirtOutB2C,
        BananaVirtOutB2LFE,
        BananaVirtOutB2SL,
        BananaVirtOutB2SR,
        BananaVirtOutB2BL,
        BananaVirtOutB2BR,
        // Potato
        Strip4L = 6,
        Strip4R,

        Strip5L,
        Strip5R,
        // VIRTUAL INPUTS
        PotatoVirt1InL,
        PotatoVirt1InR,
        PotatoVirt1InC,
        PotatoVirt1InLFE,
        PotatoVirt1InSL,
        PotatoVirt1InSR,
        PotatoVirt1InBL,
        PotatoVirt1InBR,

        PotatoVirt2InL,
        PotatoVirt2InR,
        PotatoVirt2InC,
        PotatoVirt2InLFE,
        PotatoVirt2InSL,
        PotatoVirt2InSR,
        PotatoVirt2InBL,
        PotatoVirt2InBR,

        PotatoVirt3InL,
        PotatoVirt3InR,
        PotatoVirt3InC,
        PotatoVirt3InLFE,
        PotatoVirt3InSL,
        PotatoVirt3InSR,
        PotatoVirt3InBL,
        PotatoVirt3InBR,
        // HARDWARE OUTPUTS
        PotatoOutA1L = 0,
        PotatoOutA1R,
        PotatoOutA1C,
        PotatoOutA1LFE,
        PotatoOutA1SL,
        PotatoOutA1SR,
        PotatoOutA1BL,
        PotatoOutA1BR,

        PotatoOutA2L,
        PotatoOutA2R,
        PotatoOutA2C,
        PotatoOutA2LFE,
        PotatoOutA2SL,
        PotatoOutA2SR,
        PotatoOutA2BL,
        PotatoOutA2BR,

        PotatoOutA3L,
        PotatoOutA3R,
        PotatoOutA3C,
        PotatoOutA3LFE,
        PotatoOutA3SL,
        PotatoOutA3SR,
        PotatoOutA3BL,
        PotatoOutA3BR,

        PotatoOutA4L,
        PotatoOutA4R,
        PotatoOutA4C,
        PotatoOutA4LFE,
        PotatoOutA4SL,
        PotatoOutA4SR,
        PotatoOutA4BL,
        PotatoOutA4BR,

        PotatoOutA5L,
        PotatoOutA5R,
        PotatoOutA5C,
        PotatoOutA5LFE,
        PotatoOutA5SL,
        PotatoOutA5SR,
        PotatoOutA5BL,
        PotatoOutA5BR,
        // VIRTUAL OUTPUTS
        PotatoVirtOutB1L,
        PotatoVirtOutB1R,
        PotatoVirtOutB1C,
        PotatoVirtOutB1LFE,
        PotatoVirtOutB1SL,
        PotatoVirtOutB1SR,
        PotatoVirtOutB1BL,
        PotatoVirtOutB1BR,

        PotatoVirtOutB2L,
        PotatoVirtOutB2R,
        PotatoVirtOutB2C,
        PotatoVirtOutB2LFE,
        PotatoVirtOutB2SL,
        PotatoVirtOutB2SR,
        PotatoVirtOutB2BL,
        PotatoVirtOutB2BR,

        PotatoVirtOutB3L,
        PotatoVirtOutB3R,
        PotatoVirtOutB3C,
        PotatoVirtOutB3LFE,
        PotatoVirtOutB3SL,
        PotatoVirtOutB3SR,
        PotatoVirtOutB3BL,
        PotatoVirtOutB3BR,
    }
}