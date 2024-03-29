﻿using Marsen.NetCore.Dojo.Classes.Joey.ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.ShowHands
{
    public class ShowHandTests
    {
        private readonly ShowHand _showHand = new("Tom", "Lee");

        [Fact(DisplayName = "四條 vs 三條")]
        public void FourOfAKind_ThreeOfAKind()
        {
            var actual = _showHand.Duel("S3,C3,D3,H3,H7", "S3,C3,D3,H7,H8");
            Assert.Equal("Tom Win, Because Four Of a Kind", actual);
        }

        [Fact(DisplayName = "二對 vs 三條")]
        public void TwoPairs_ThreeOfAKind()
        {
            var actual = _showHand.Duel("S3,C3,D5,H5,H7", "S3,C3,D3,H7,H8");
            Assert.Equal("Lee Win, Because Three Of a Kind", actual);
        }

        [Fact(DisplayName = "三條 vs 三條，Key Card 6")]
        public void ThreeOfAKind_ThreeOfAKind_With_Key_Card_6()
        {
            var actual = _showHand.Duel("S3,C4,D5,H5,C5", "S3,C4,D6,H6,C6");
            Assert.Equal("Lee Win, Because Three Of a Kind, Key Card 6", actual);
        }

        [Fact(DisplayName = "三條 vs 三條, 平手")]
        public void ThreeOfAKind_ThreeOfAKind_End_In_A_Tie()
        {
            var actual = _showHand.Duel("S3,C4,D6,H6,C6", "S3,C4,D6,H6,C6");
            Assert.Equal("End in a tie", actual);
        }

        [Fact(DisplayName = "二條 vs 二條, Key Card 9")]
        public void TwoPair_TwoPair_With_Key_Card_9()
        {
            var actual = _showHand.Duel("S4,C4,D5,H5,C7", "S4,C4,D5,S5,S9");
            Assert.Equal("Lee Win, Because Two Pair, Key Card 9", actual);
        }

        [Fact(DisplayName = "二條 vs 二條，平手")]
        public void TwoPair_TwoPair()
        {
            var actual = _showHand.Duel("S4,C4,D5,H5,S7", "S4,C4,D5,S5,S7");
            Assert.Equal("End in a tie", actual);
        }

        [Fact(DisplayName = "二條 vs 一條")]
        public void TwoPair_OnePair()
        {
            var actual = _showHand.Duel("S4,C4,D5,H5,C7", "S4,C4,D5,S6,S7");
            Assert.Equal("Tom Win, Because Two Pair", actual);
        }

        [Fact(DisplayName = "一條 vs 高牌")]
        public void OnePair_HighCard()
        {
            var actual = _showHand.Duel("S2,C4,D5,H9,C7", "S4,C4,D5,S6,S7");
            Assert.Equal("Lee Win, Because One Pair", actual);
        }

        [Fact(DisplayName = "三條 vs 順子")]
        public void ThreeOfAKind_Straight()
        {
            var actual = _showHand.Duel("S2,C4,D9,H9,C9", "S8,C4,D5,S6,S7");
            Assert.Equal("Lee Win, Because Straight", actual);
        }

        [Fact(DisplayName = "順子 vs 同花")]
        public void Straight_Flush()
        {
            var actual = _showHand.Duel("S8,C4,D5,S6,S7", "S2,S4,S9,S6,S5");
            Assert.Equal("Lee Win, Because Flush", actual);
        }

        [Fact(DisplayName = "同花順 vs 同花順，Key Card K")]
        public void StraightFlush_StraightFlush_With_Key_Card_K()
        {
            var actual = _showHand.Duel("SA,SK,SJ,S10,SQ", "S2,S4,SA,S3,S5");
            Assert.Equal("Tom Win, Because Straight Flush, Key Card K", actual);
        }

        [Fact(DisplayName = "同花順 vs 同花順，Key Card Q")]
        public void StraightFlush_StraightFlush_With_Key_Card_Q()
        {
            var actual = _showHand.Duel("D9,D8,D7,D5,D6", "S9,S8,SJ,S10,SQ");
            Assert.Equal("Lee Win, Because Straight Flush, Key Card Q", actual);
        }

        [Fact(DisplayName = "同花順 vs 同花順，Key Card J")]
        public void StraightFlush_StraightFlush_With_Key_Card_J()
        {
            var actual = _showHand.Duel("D9,D8,D10,DJ,D7", "S9,S8,S7,S10,S6");
            Assert.Equal("Tom Win, Because Straight Flush, Key Card J", actual);
        }

        [Fact(DisplayName = "同花順 vs 同花順，Key Card A")]
        public void StraightFlush_StraightFlush_With_Key_Card_A()
        {
            var actual = _showHand.Duel("D9,DQ,D10,DJ,DK", "SA,SK,SQ,S10,SJ");
            Assert.Equal("Lee Win, Because Straight Flush, Key Card A", actual);
        }

        [Fact(DisplayName = "同花順 vs 同花順，A2345 大於 910JQK")]
        public void StraightFlush_StraightFlush_A2345_Greater_Than_910JQK()
        {
            var actual = _showHand.Duel("D9,DQ,D10,DJ,DK", "SA,S2,S3,S4,S5");
            Assert.Equal("Lee Win, Because Straight Flush, Key Card A", actual);
        }


        [Fact(DisplayName = "同花順 vs 同花順，紅心大於方塊")]
        public void StraightFlush_Heart_Greater_Than_Diamond()
        {
            var actual = _showHand.Duel("H5,H6,H7,H8,H9", "D5,D6,D7,D8,D9");
            Assert.Equal("Tom Win, Because Straight Flush, And Heart", actual);
        }

        [Fact(DisplayName = "四條 5 + 梅花 9 vs 四條 5 + 方塊 9 ，Key Card 紅心大於梅花")]
        public void FourOfAKind_Heart_Greater_Than_Diamond()
        {
            var actual = _showHand.Duel("H5,C5,S5,D5,H9", "D5,H5,S5,C5,C9");
            Assert.Equal("Tom Win, Because Four Of a Kind, And Heart", actual);
        }

        [Fact(DisplayName = "四條 5 + 梅花 9 vs 四條 5 + 方塊 9 ，Key Card 方塊大於梅花")]
        public void FourOfAKind_Diamond_Greater_Than_Club()
        {
            var actual = _showHand.Duel("D5,H5,S5,C5,C9", "H5,C5,S5,D5,D9");
            Assert.Equal("Lee Win, Because Four Of a Kind, And Diamond", actual);
        }

        [Fact(DisplayName = "紅心同花 vs 梅花同花，Key Card 相同，紅心大於梅花")]
        public void Flush_Heart_Greater_Than_Diamond()
        {
            var actual = _showHand.Duel("H6,H5,H9,H7,H3", "C9,C3,C6,C5,C7");
            Assert.Equal("Tom Win, Because Flush, And Heart", actual);
        }

        [Fact(DisplayName = "梅花同花 vs 方塊同花，Key Card 相同，方塊大於梅花")]
        public void Flush_Diamond_Greater_Than_Club()
        {
            var actual = _showHand.Duel("C9,C3,C6,C5,C7", "D6,D5,D9,D7,D3");
            Assert.Equal("Lee Win, Because Flush, And Diamond", actual);
        }

        [Fact(DisplayName = "順子 vs 順子，平手")]
        public void Straight_End_in_a_tie()
        {
            var actual = _showHand.Duel("D9,C8,S6,H5,C7", "D6,S5,C9,D7,H8");
            Assert.Equal("End in a tie", actual);
        }

        [Fact(DisplayName = "兩條 vs 兩條, Key Card 黑桃大於梅花")]
        public void TwoPairs_Spade_Greater_Than_Club()
        {
            var actual = _showHand.Duel("D9,C9,S6,H6,C7", "D6,S6,C9,D9,S7");
            Assert.Equal("Lee Win, Because Two Pair, And Spades", actual);
        }

        [Fact(DisplayName = "兩條 vs 兩條, Key Card 黑桃大於紅心")]
        public void TwoPairs_Spade_Greater_Than_Heart()
        {
            var actual = _showHand.Duel("D9,C9,S6,H6,S7", "D6,S6,C9,D9,H7");
            Assert.Equal("Tom Win, Because Two Pair, And Spades", actual);
        }

        [Fact(DisplayName = "高牌 vs 高牌, Key Card 黑桃大於方塊")]
        public void HighCard_Spade_Greater_Than_Diamond()
        {
            var actual = _showHand.Duel("D4,S6,H5,S3,S10", "D10,S5,C8,D9,H7");
            Assert.Equal("Tom Win, Because High Card, And Spades", actual);
        }

        [Fact(DisplayName = "高牌 vs 高牌, Key Card 最大張相同，第二張黑桃大於方塊")]
        public void HighCard_Same_Largest_Card_Spade_Greater_Than_Diamond()
        {
            var actual = _showHand.Duel("D4,S6,H5,D9,S10", "S10,S5,C8,S9,H7");
            Assert.Equal("Lee Win, Because High Card, And Spades", actual);
        }

        [Fact(DisplayName = "高牌 vs 高牌, Key Card 最大張相同，第二張方塊大於梅花")]
        public void HighCard_Same_Top2_Card_Diamond_Greater_Than_Club()
        {
            var actual = _showHand.Duel("D8,S6,H5,S9,S10", "S10,S5,C8,S9,H7");
            Assert.Equal("Tom Win, Because High Card, And Diamond", actual);
        }

        [Fact(DisplayName = "一條 vs 一條, 8 8 7 9 10 大於 8 8 5 9 10")]
        public void OnePair_8_8_7_9_10_Greater_Than_8_8_5_9_10()
        {
            var actual = _showHand.Duel("C8,S8,H5,S9,S10", "S10,D8,H8,S9,H7");
            Assert.Equal("Lee Win, Because One Pair, Key Card 7", actual);
        }

        [Fact(DisplayName = "一條 vs 一條, 平手")]
        public void OnePair_Draw()
        {
            var actual = _showHand.Duel("C8,S8,C7,H9,D10", "S10,D8,H8,S9,H7");
            Assert.Equal("End in a tie", actual);
        }
    }
}