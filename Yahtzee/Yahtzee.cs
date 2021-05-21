using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class Yahtzee : Form
    {
        Image[] plaatje = new Image[6];
        Image[] plaatje2 = new Image[6];
        Random random = new Random();
        List<int> getal = new List<int>();
        Label[] labels = new Label[13];
        Label[] een = new Label[19];
        Label[] twee = new Label[19];
        Label[] drie = new Label[19];
        Label[] vier = new Label[19];
        Label[] vijf = new Label[19];
        Label[] zes = new Label[19];
        //int[] getal = new int[5];
        int[] deck = new int[5];
        bool[] scores = new bool[13];
        bool[] scorescomputer = new bool[13];

        int aantalgooi = 0;
        int klik = 0;
        int bovenscore = 0;
        int onderscore = 0;
        int bonus = 0;
        int totalescore = 0;

        int bovenscorec = 0;
        int onderscorec = 0;
        int bonusc = 0;
        int totalescorec = 0;

        int rondes = 0;
        int spel = 1;
        int beurten = 13;
        bool gespeeld = false;
        bool computer = false;
        bool[] zichtbaar = new bool[5];
        string player;
        PictureBox[] dobbelsteen = new PictureBox[5];
        PictureBox[] dobbelclaim = new PictureBox[5];


        public Yahtzee()
        {
            InitializeComponent();

            for (int i = 0; i < plaatje.Length; i++)
            {
                plaatje[i] = Image.FromFile(@"..\..\img\" + (i + 1) + ".png");
                plaatje2[i] = Image.FromFile(@"..\..\img\" + (i + 1) + "_2.png");
            }

            for (int i = 0; i < zichtbaar.Length; i++)
            {
                zichtbaar[i] = true;
            }

            dobbelsteen[0] = picDobbel1;
            dobbelsteen[1] = picDobbel2;
            dobbelsteen[2] = picDobbel3;
            dobbelsteen[3] = picDobbel4;
            dobbelsteen[4] = picDobbel5;

            dobbelclaim[0] = dobbelClaim1;
            dobbelclaim[1] = dobbelClaim2;
            dobbelclaim[2] = dobbelClaim3;
            dobbelclaim[3] = dobbelClaim4;
            dobbelclaim[4] = dobbelClaim5;

            labels[0] = lblEnen;
            labels[1] = lblTweeën;
            labels[2] = lblDrieën;
            labels[3] = lblVieren;
            labels[4] = lblVijven;
            labels[5] = lblZessen;
            labels[6] = lblThree;
            labels[7] = lblCarré;
            labels[8] = lblFull;
            labels[9] = lblKlein;
            labels[10] = lblGroot;
            labels[11] = lblYahtzee;
            labels[12] = lblKans;

            een[0] = EenEnen;
            een[1] = EenTweeen;
            een[2] = EenDrieen;
            een[3] = EenVieren;
            een[4] = EenVijven;
            een[5] = EenZessen;
            een[6] = EenTotaalEen;
            een[7] = EenBonus;
            een[8] = EenTotaalDeelEen;
            een[9] = EenThree;
            een[10] = EenCarre;
            een[11] = EenFullHouse;
            een[12] = EenKleineStraat;
            een[13] = EenGroteStraat;
            een[14] = EenYahtzee;
            een[15] = EenKans;
            een[16] = EenTotaalOnder;
            een[17] = EenTotaalBoven;
            een[18] = EenTotaalGeneraal;

            twee[0] = TweeEnen;
            twee[1] = TweeTweeen;
            twee[2] = TweeDrieen;
            twee[3] = TweeVieren;
            twee[4] = TweeVijven;
            twee[5] = TweeZessen;
            twee[6] = TweeTotaalEen;
            twee[7] = TweeBonus;
            twee[8] = TweeTotaalDeelEen;
            twee[9] = TweeThree;
            twee[10] = TweeCarre;
            twee[11] = TweeFullHouse;
            twee[12] = TweeKleineStraat;
            twee[13] = TweeGroteStraat;
            twee[14] = TweeYahtzee;
            twee[15] = TweeKans;
            twee[16] = TweeTotaalOnder;
            twee[17] = TweeTotaalBoven;
            twee[18] = TweeTotaalGeneraal;

            drie[0] = DrieEnen;
            drie[1] = DrieTweeen;
            drie[2] = DrieDrieen;
            drie[3] = DrieVieren;
            drie[4] = DrieVijven;
            drie[5] = DrieZessen;
            drie[6] = DrieTotaalEen;
            drie[7] = DrieBonus;
            drie[8] = DrieTotaalDeelEen;
            drie[9] = DrieThree;
            drie[10] = DrieCarre;
            drie[11] = DrieFullHouse;
            drie[12] = DrieKleineStraat;
            drie[13] = DrieGroteStraat;
            drie[14] = DrieYahtzee;
            drie[15] = DrieKans;
            drie[16] = DrieTotaalOnder;
            drie[17] = DrieTotaalBoven;
            drie[18] = DrieTotaalGeneraal;

            vier[0] = VierEnen;
            vier[1] = VierTweeen;
            vier[2] = VierDrieen;
            vier[3] = VierVieren;
            vier[4] = VierVijven;
            vier[5] = VierZessen;
            vier[13] = VierTotaalEen;
            vier[14] = VierBonus;
            vier[15] = VierTotaalDeelEen;
            vier[6] = VierThree;
            vier[7] = VierCarre;
            vier[8] = VierFullHouse;
            vier[9] = VierKleineStraat;
            vier[10] = VierGroteStraat;
            vier[11] = VierYahtzee;
            vier[12] = VierKans;
            vier[16] = VierTotaalOnder;
            vier[17] = VierTotaalBoven;
            vier[18] = VierTotaalGeneraal;

            vijf[0] = VijfEnen;
            vijf[1] = VijfTweeen;
            vijf[2] = VijfDrieen;
            vijf[3] = VijfVieren;
            vijf[4] = VijfVijven;
            vijf[5] = VijfZessen;
            vijf[13] = VijfTotaalEen;
            vijf[14] = VijfBonus;
            vijf[15] = VijfTotaalDeelEen;
            vijf[6] = VijfThree;
            vijf[7] = VijfCarre;
            vijf[8] = VijfFullHouse;
            vijf[9] = VijfKleineStraat;
            vijf[10] = VijfGroteStraat;
            vijf[11] = VijfYahtzee;
            vijf[12] = VijfKans;
            vijf[16] = VijfTotaalOnder;
            vijf[17] = VijfTotaalBoven;
            vijf[18] = VijfTotaalGeneraal;

            zes[0] = ZesEnen;
            zes[1] = ZesTweeen;
            zes[2] = ZesDrieen;
            zes[3] = ZesVieren;
            zes[4] = ZesVijven;
            zes[5] = ZesZessen;
            zes[13] = ZesTotaalEen;
            zes[14] = ZesBonus;
            zes[15] = ZesTotaalDeelEen;
            zes[6] = ZesThree;
            zes[7] = ZesCarre;
            zes[8] = ZesFullHouse;
            zes[9] = ZesKleineStraat;
            zes[10] = ZesGroteStraat;
            zes[11] = ZesYahtzee;
            zes[12] = ZesKans;
            zes[16] = ZesTotaalOnder;
            zes[17] = ZesTotaalBoven;
            zes[18] = ZesTotaalGeneraal;


            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
                scores[i] = false;
                scorescomputer[i] = false;
            }

            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rondes = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rondes = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            rondes = 3;
        }

        private void BtnAlleen_Click(object sender, EventArgs e)
        {
            if (txtNaam.TextLength > 1 && rondes > 0)
            {
                player = txtNaam.Text;
                theTabControl.SelectedTab = gamePagina;
                lblPlayer.Text = "Speler: " + player;
                lblEnd.Text = "Hello: " + player;
                lblSpel.Text = "Spel: " + spel;
                lblBeurten.Text = "Beurten: " + beurten;
                panelDuel.Visible = false;
                lblComputer.Visible = false;
                computer = false;
            }
            else if (txtNaam.TextLength <= 1)
            {
                MessageBox.Show("Vul een naam in", "FOUT");
            }
            else if (rondes == 0)
            {
                MessageBox.Show("Selecteer hoeveel rondes", "FOUT");
            }

        }

        private void BtnComputer_Click(object sender, EventArgs e)
        {
            if (txtNaam.TextLength > 1 && rondes > 0)
            {
                computer = true;
                player = txtNaam.Text;
                theTabControl.SelectedTab = gamePagina;
                lblPlayer.Text = "Speler: " + player;
                lblEnd.Text = "Hello: " + player;
                lblSpel.Text = "Spel: " + spel;
                lblBeurten.Text = "Beurten: " + beurten;
                panelDuel.Visible = true;
                lblComputer.Visible = true;
            }
            else if (txtNaam.TextLength <= 1)
            {
                MessageBox.Show("Vul een naam in", "FOUT");
            }
            else if (rondes == 0)
            {
                MessageBox.Show("Selecteer hoeveel rondes", "FOUT");
            }
            
        }

        private void BtnGooi_Click(object sender, EventArgs e)
        {
            Gooi();
        }

        private void btnSpeel_Click(object sender, EventArgs e)
        {
            if(gespeeld)
            {
                ResetDeck();
                if (CheckIfFinished())
                {
                    totalescore = totalescore + bovenscore + onderscore + bonus;
                    totalescorec = totalescorec + bovenscorec + onderscorec + bonusc;
                    bovenscore = 0;
                    onderscore = 0;
                    bonus = 0;
                    bovenscorec = 0;
                    onderscorec = 0;
                    bonusc = 0;
                    spel++;
                    if (spel > rondes)
                    {

                        Einde();
                       
                    }
                    else
                    {
                        lblSpel.Text = "Spel: " + spel;

                        for (int i = 0; i < labels.Length; i++)
                        {
                            scores[i] = false;
                            scorescomputer[i] = false;
                        }
                        MessageBox.Show("Ronde: " + spel.ToString());
                    }
                }

                panelSpeel.Visible = false;
                gespeeld = false;
            } else
            {
                MessageBox.Show("Kies wat je wil spelen", "FOUT");
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void PicDobbel1_Click(object sender, EventArgs e)
        {
            ClaimDobbel(0);
        }

        private void PicDobbel2_Click(object sender, EventArgs e)
        {
            ClaimDobbel(1);
        }

        private void PicDobbel3_Click(object sender, EventArgs e)
        {
            ClaimDobbel(2);
        }

        private void PicDobbel4_Click(object sender, EventArgs e)
        {
            ClaimDobbel(3);
        }

        private void PicDobbel5_Click(object sender, EventArgs e)
        {
            ClaimDobbel(4);
        }

        private void DobbelClaim1_Click(object sender, EventArgs e)
        {
            Deck(0);
        }

        private void DobbelClaim2_Click(object sender, EventArgs e)
        {
            Deck(1);
        }

        private void DobbelClaim3_Click(object sender, EventArgs e)
        {
            Deck(2);
        }

        private void DobbelClaim4_Click(object sender, EventArgs e)
        {
            Deck(3);
        }

        private void DobbelClaim5_Click(object sender, EventArgs e)
        {
            Deck(4);
        }

        private void lblEnen_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenEnen.Text = Convert.ToString(Check(0));
                SetScore(0, spel);
            } else if (spel == 2)
            {
                TweeEnen.Text = Convert.ToString(Check(0));
                SetScore(0, spel);
            } else
            {
                DrieEnen.Text = Convert.ToString(Check(0));
                SetScore(0,spel);
            }
            


        }

        private void lblTweeën_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenTweeen.Text = Convert.ToString(Check(1));
                SetScore(1, spel);
            }
            else if (spel == 2)
            {
                TweeTweeen.Text = Convert.ToString(Check(1));
                SetScore(1, spel);
            }
            else
            {
                DrieTweeen.Text = Convert.ToString(Check(1));
                SetScore(1, spel);
            }

        }

        private void lblDrieën_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenDrieen.Text = Convert.ToString(Check(2));
                SetScore(2, spel);
            }
            else if (spel == 2)
            {
                TweeDrieen.Text = Convert.ToString(Check(2));
                SetScore(2, spel);
            }
            else
            {
                DrieDrieen.Text = Convert.ToString(Check(2));
                SetScore(2, spel);
            }
        }

        private void lblVieren_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenVieren.Text = Convert.ToString(Check(3));
                SetScore(3, spel);
            }
            else if (spel == 2)
            {
                TweeVieren.Text = Convert.ToString(Check(3));
                SetScore(3, spel);
            }
            else
            {
                DrieVieren.Text = Convert.ToString(Check(3));
                SetScore(3, spel);
            }
        }

        private void lblVijven_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenVijven.Text = Convert.ToString(Check(4));
                SetScore(4, spel);
            }
            else if (spel == 2)
            {
                TweeVijven.Text = Convert.ToString(Check(4));
                SetScore(4, spel);
            }
            else
            {
                DrieVijven.Text = Convert.ToString(Check(4));
                SetScore(4, spel);
            }

        }

        private void lblZessen_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenZessen.Text = Convert.ToString(Check(5));
                SetScore(5, spel);
            }
            else if (spel == 2)
            {
                TweeZessen.Text = Convert.ToString(Check(5));
                SetScore(5, spel);
            }
            else
            {
                DrieZessen.Text = Convert.ToString(Check(5));
                SetScore(5, spel);
            }

        }

        private void lblThree_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenThree.Text = Convert.ToString(Check(6));
                SetScore(6, spel);
            }
            else if (spel == 2)
            {
                TweeThree.Text = Convert.ToString(Check(6));
                SetScore(6, spel);
            }
            else
            {
                DrieThree.Text = Convert.ToString(Check(6));
                SetScore(6, spel);
            }
        }

        private void lblCarré_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenCarre.Text = Convert.ToString(Check(7));
                SetScore(7, spel);
            }
            else if (spel == 2)
            {
                TweeCarre.Text = Convert.ToString(Check(7));
                SetScore(7, spel);
            }
            else
            {
                DrieCarre.Text = Convert.ToString(Check(7));
                SetScore(7, spel);
            }

        }

        private void lblFull_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenFullHouse.Text = Convert.ToString(Check(8));
                SetScore(8, spel);
            }
            else if (spel == 2)
            {
                TweeFullHouse.Text = Convert.ToString(Check(8));
                SetScore(8, spel);
            }
            else
            {
                DrieFullHouse.Text = Convert.ToString(Check(8));
                SetScore(8, spel);
            }
        }

        private void lblKlein_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenKleineStraat.Text = Convert.ToString(Check(9));
                SetScore(9, spel);
            }
            else if (spel == 2)
            {
                TweeKleineStraat.Text = Convert.ToString(Check(9));
                SetScore(9, spel);
            }
            else
            {
                DrieKleineStraat.Text = Convert.ToString(Check(9));
                SetScore(9, spel);
            }
        }

        private void lblGroot_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenGroteStraat.Text = Convert.ToString(Check(10));
                SetScore(10, spel);
            }
            else if (spel == 2)
            {
                TweeGroteStraat.Text = Convert.ToString(Check(10));
                SetScore(10, spel);
            }
            else
            {
                DrieGroteStraat.Text = Convert.ToString(Check(10));
                SetScore(10, spel);
            }
        }

        private void lblYahtzee_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenYahtzee.Text = Convert.ToString(Check(11));
                SetScore(11, spel);
            }
            else if (spel == 2)
            {
                TweeYahtzee.Text = Convert.ToString(Check(11));
                SetScore(11, spel);
            }
            else
            {
                DrieYahtzee.Text = Convert.ToString(Check(11));
                SetScore(11, spel);
            }
        }

        private void lblKans_Click(object sender, EventArgs e)
        {
            if (spel == 1)
            {
                EenKans.Text = Convert.ToString(Check(12));
                SetScore(12, spel);
            }
            else if (spel == 2)
            {
                TweeKans.Text = Convert.ToString(Check(12));
                SetScore(12, spel);
            }
            else
            {
                DrieKans.Text = Convert.ToString(Check(12));
                SetScore(12, spel);
            }
        }


        private void Gooi()
        {
            getal.Clear();
            
            
            for (int i = 0; i < 6; i++)
            {
                getal.Add(random.Next(0, 6));
            }
            

            for (int i = 0; i < dobbelsteen.Length; i++)
            {
                dobbelsteen[i].Image = plaatje[getal[i]];
                dobbelsteen[i].Visible = zichtbaar[i];
            }
            aantalgooi++;
            if (aantalgooi == 3)
            {
                btnGooi.Visible = false;
            }

        }

        private bool CheckIfFinished()
        {
            int check = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if(scores[i] == true)
                {
                    check++;
                }
            }
            if (check == 13)
            {
                beurten = 13;     
                return true;
            } else
            {
                return false;
            }
        }

        private void ClaimDobbel(int dobbel)
        {
            zichtbaar[dobbel] = false;
            dobbelsteen[dobbel].Visible = zichtbaar[dobbel];
            dobbelclaim[dobbel].Visible = true;
            dobbelclaim[dobbel].Image = plaatje2[getal[dobbel]];
            deck[dobbel] = getal[dobbel];
            klik++;
            if (klik == 5)
            {
                Choose();
            }
        }

        private void Choose()
        {
            SortDeck();
            btnSpeel.Visible = true;
            btnGooi.Visible = false;
            panelSpeel.Visible = true;
            int check = 0;
            for (int i = 0; i < labels.Length; i++)
            {
                if (CheckIfUsed(i) == false)
                {
                    labels[i].Visible = true;
                    check++;
                }

            }

            if (check == 0)
            {
                gespeeld = true;
            }
            else
            {
                gespeeld = false;
            }

        }

        private void SetScore(int nummer, int spell)
        {
            gespeeld = true;
            beurten--;
            scores[nummer] = true;
            if(spell == 1)
            {
                if (nummer < 6)
                {
                    bovenscore += Check(nummer);
                    EenTotaalEen.Text = bovenscore.ToString();
                    if (bovenscore >= 63)
                    {
                        bonus = 35;
                        
                    }
                    EenBonus.Text = bonus.ToString();
                    EenTotaalDeelEen.Text = (bovenscore + bonus).ToString();
                    EenTotaalBoven.Text = (bovenscore + bonus).ToString();
                    EenTotaalGeneraal.Text = (bovenscore + onderscore + bonus).ToString();

                }
                else
                {
                    onderscore += Check(nummer);
                    EenTotaalOnder.Text = onderscore.ToString();
                    EenTotaalGeneraal.Text = (bovenscore + onderscore + bonus).ToString();
                }
            } else if(spell == 2)
            {
                if (nummer < 6)
                {
                    bovenscore += Check(nummer);
                    TweeTotaalEen.Text = bovenscore.ToString();
                    if (bovenscore >= 63)
                    {
                        bonus = 35;

                    }
                    TweeBonus.Text = bonus.ToString();
                    TweeTotaalBoven.Text = (bovenscore + bonus).ToString();
                    TweeTotaalDeelEen.Text = (bovenscore + bonus).ToString();
                    TweeTotaalGeneraal.Text = (bovenscore + onderscore + bonus).ToString();
                }
                else
                {
                    onderscore += Check(nummer);
                    TweeTotaalOnder.Text = onderscore.ToString();
                    TweeTotaalGeneraal.Text = (bovenscore + onderscore + bonus).ToString();
                    
                }
            } else
            {
                if (nummer < 6)
                {
                    bovenscore += Check(nummer);
                    DrieTotaalEen.Text = bovenscore.ToString();
                    if (bovenscore >= 63)
                    {
                        bonus = 35;
                    }
                    
                    DrieBonus.Text = bonus.ToString();
                    DrieTotaalBoven.Text = (bovenscore + bonus).ToString();
                    DrieTotaalDeelEen.Text = (bovenscore + bonus).ToString();
                    DrieTotaalGeneraal.Text = (bovenscore + onderscore + bonus).ToString();
                    

                }
                else
                {
                    onderscore += Check(nummer);
                    DrieTotaalOnder.Text = onderscore.ToString();
                    DrieTotaalGeneraal.Text = (bovenscore + onderscore + bonus).ToString();
                }
            }
            

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
            }

            lblBeurten.Text = "Beurten: " + beurten;
            if (CheckIfFinished() && spel > rondes)
            {
                btnSpeel.Text = "Einde!";
                MessageBox.Show("Einde");
            }

            if (computer)
            {
                Computer();
            }

            lblPlayerScore.Text = "Speler: " + NaamNummer(nummer);
            
        }

        private bool CheckIfUsed(int nummer)
        {
            if(scores[nummer])
            {
                return true;
            } else
            {
                return false;
            }
             
        }

        private void SortDeck()
        {
            Array.Sort(deck);
            for (int i = 0; i < deck.Length; i++)
            {
                dobbelclaim[i].Image = plaatje2[deck[i]];
            }
        }

        private void Deck(int dobbel)
        {
            if (klik < 5)
            {
                dobbelclaim[dobbel].Visible = false;
                klik--;
                dobbelsteen[dobbel].Image = plaatje[deck[dobbel]];
                zichtbaar[dobbel] = true;
                dobbelsteen[dobbel].Visible = zichtbaar[dobbel];
                
            }


        }

        private void Computer()
        {
            int hoogste = 0;
            int nummer = 0;

            int rnd = random.Next(0, 10);

            if (rnd % 5 == 0)
            {
                rnd = random.Next(0, 10);
                Goed(rnd); 
                for (int i = 0; i < deck.Length; i++)
                {
                    deck[i] = getal[i];
                }
            } else
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    deck[i] = random.Next(0, 6);
                }
            }

            Array.Sort(deck);

            for (int i = 0; i < labels.Length; i++)
            {
                if (Check(i) > hoogste && scorescomputer[i]==false)
                {
                    hoogste = Check(i);
                    nummer = i;
                }
                
            }
 
            
            if (deck[1] == deck[0] && deck[2] == deck[1] && deck[4] == deck[3] && deck[4] > deck[1] || deck[1] == deck[0] && deck[3] == deck[2] && deck[4] == deck[3] && deck[4] > deck[1])
            {
                hoogste = Check(8);
                nummer = 8;
            }

            if (nummer == 0 && scorescomputer[0] == true )
            {
                nummer = Array.IndexOf(scorescomputer, false);
            }

            scorescomputer[nummer] = true;

            if (spel == 1)
            {
                vier[nummer].Text = hoogste.ToString();

                if (nummer < 6)
                {
                    bovenscorec += Check(nummer);
                    if (bovenscorec >= 63)
                    {
                        bonusc = 35;
                    }
                    vier[13].Text = bovenscorec.ToString();
                    vier[14].Text = bonusc.ToString();
                    vier[15].Text = (bovenscorec + bonusc).ToString();
                    vier[17].Text = (bovenscorec + bonusc).ToString();
                    vier[18].Text = (onderscorec + bovenscorec + bonusc).ToString();
                }
                else
                {
                    onderscorec += Check(nummer);
                    vier[16].Text = onderscorec.ToString();
                    vier[18].Text = (onderscorec + bovenscorec + bonusc).ToString();
                }

            } else if(spel == 2)
            {
                vijf[nummer].Text = hoogste.ToString();

                if (nummer < 6)
                {
                    bovenscorec += Check(nummer);
                    if (bovenscorec >= 63)
                    {
                        bonusc = 35;
                    }
                    vijf[13].Text = bovenscorec.ToString();
                    vijf[14].Text = bonusc.ToString();
                    vijf[15].Text = (bovenscorec + bonusc).ToString();
                    vijf[17].Text = (bovenscorec + bonusc).ToString();
                    vijf[18].Text = (onderscorec + bovenscorec + bonusc).ToString();
                }
                else
                {
                    onderscorec += Check(nummer);
                    vijf[16].Text = onderscorec.ToString();
                    vijf[18].Text = (onderscorec + bovenscorec + bonusc).ToString();
                }
            } else
            {
                zes[nummer].Text = hoogste.ToString();

                if (nummer < 6)
                {
                    bovenscorec += Check(nummer);
                    if (bovenscorec >= 63)
                    {
                        bonusc = 35;
                    }
                    zes[13].Text = bovenscorec.ToString();
                    zes[14].Text = bonusc.ToString();
                    zes[15].Text = (bovenscorec + bonusc).ToString();
                    zes[17].Text = (bovenscorec + bonusc).ToString();
                    zes[18].Text = (onderscorec + bovenscorec + bonusc).ToString();
                }
                else
                {
                    onderscorec += Check(nummer);
                    zes[16].Text = onderscorec.ToString();
                    zes[18].Text = (onderscorec + bovenscorec + bonusc).ToString();
                }
            }

            lblComputerScore.Text = "Computer: " + NaamNummer(nummer);
        }

        private string NaamNummer(int nummer)
        {
            string naam = "";

            switch (nummer)
            {
                case 0:
                    naam = "Enen";
                    break;
                case 1:
                    naam = "Tweeën";
                    break;
                case 2:
                    naam = "Drieën";
                    break;
                case 3:
                    naam = "Vieren";
                    break;
                case 4:
                    naam = "Vijven";
                    break;
                case 5:
                    naam = "Zessen";
                    break;
                case 6:
                    naam = "Three of a kind";
                    break;
                case 7:
                    naam = "Carré";
                    break;
                case 8:
                    naam = "Full House";
                    break;
                case 9:
                    naam = "Kleine Straat";
                    break;
                case 10:
                    naam = "Grote Straat";
                    break;
                case 11:
                    naam = "Yahtzee";
                    break;
                case 12:
                    naam = "Kans";
                    break;
            }
            return naam;
        }

        private int Check(int nummer)
        {
            int score = 0;
            int vermenigvuldig = 0;
            if (nummer < 6)
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    if (deck[i] == nummer)
                    {
                        vermenigvuldig++;
                    }
                }
                score = (nummer + 1) * vermenigvuldig;
            }
            else if (nummer == 6)
            {
                if (deck[1] == deck[0] && deck[2] == deck[1] || deck[2] == deck[1] && deck[3] == deck[2] || deck[3] == deck[2] && deck[4] == deck[3])
                {
                    for (int i = 0; i < deck.Length; i++)
                    {
                        score = score + deck[i] + 1;
                    }
                }
            }
            else if (nummer == 7)
            {
                if (deck[1] == deck[0] && deck[2] == deck[1] && deck[3] == deck[2] || deck[2] == deck[1] && deck[3] == deck[2] && deck[4] == deck[3])
                {
                    for (int i = 0; i < deck.Length; i++)
                    {
                        score = score + deck[i] + 1;
                    }
                }
            }
            else if (nummer == 8)
            {
                if (deck[1] == deck[0] && deck[2] == deck[1] && deck[4] == deck[3] && deck[4] > deck[1] || deck[1] == deck[0] && deck[3] == deck[2] && deck[4] == deck[3] && deck[4] > deck[1])
                {
                    score = 25;
                }

            }
            else if (nummer == 9)
            {
                if (deck[1] == deck[0] + 1 && deck[2] == deck[1] + 1 && deck[3] == deck[2] + 1 || deck[2] == deck[1] + 1 && deck[3] == deck[2] + 1 && deck[4] == deck[3] + 1 || deck[1] == deck[0] + 1 && deck[2] == deck[1] && deck[3] == deck[2] + 1 && deck[4] == deck[3] + 1 || deck[1] == deck[0] + 1 &&  deck[2] == deck[1] + 1 && deck[3] == deck[2] && deck[4] == deck[3] + 1)
                {
                    score = 30;
                }
            }
            else if (nummer == 10)
            {
                if (deck[1] == deck[0] + 1 && deck[2] == deck[1] + 1 && deck[3] == deck[2] + 1 && deck[4] == deck[3] + 1)
                {
                    score = 40;
                }
            }
            else if (nummer == 11)
            {
                int yahtzee = 0;
                for (int i = 0; i < deck.Length - 1; i++)
                {
                    if (deck[i+1] == deck[i])
                    {
                        yahtzee++;
                    }
                    
                }
                if(yahtzee == 4)
                {
                    score = 50;
                }
            }
            else
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    score = score + deck[i] + 1;
                }
            }

            return score;
        }

        private void ResetDeck()
        {
            btnGooi.Visible = true;
            panelSpeel.Visible = false;
            btnSpeel.Visible = false;
            klik = 0;
            aantalgooi = 0;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
                
            }
            for (int i = 0; i < zichtbaar.Length; i++)
            {
                zichtbaar[i] = true;
                dobbelclaim[i].Visible = false;
            }
        }

        private void ResetGame()
        {
            ResetDeck();
            txtNaam.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            onderscore = 0;
            bovenscore = 0;
            bonus = 0;
            totalescore = 0;
            onderscorec = 0;
            bovenscorec = 0;
            bonusc = 0;
            totalescorec = 0;
            spel = 1;
            beurten = 13;
            gespeeld = false;
            theTabControl.SelectedTab = hoofdPagina;
            btnSpeel.Text = "Gooi!";

            lblPlayerScore.Text = "Player: ";
            lblComputerScore.Text = "Computer: ";

            for (int i = 0; i < labels.Length; i++)
            {
                scores[i] = false;
                scorescomputer[i] = false;
            }

            for (int i = 0; i < een.Length; i++)
            {
                een[i].Text = "0";
                twee[i].Text = "0";
                drie[i].Text = "0";
                vier[i].Text = "0";
                vijf[i].Text = "0";
                zes[i].Text = "0";
            }
            
        }

        private void Einde()
        {
            theTabControl.SelectedTab = eindPagina;
            lblEndScore.Text = "Your endscore was: " + totalescore;
            picEnd.Image = Properties.Resources.wow;
            if (computer)
            {
                lblCompScore.Text = "Computer score was: " + totalescorec;
                if (totalescore > totalescorec)
                {
                    picEnd.Image = Properties.Resources.wow;
                    lblVicDef.Text = "Victory";
                } else
                {
                    picEnd.Image = Properties.Resources.defeat;
                    lblVicDef.Text = "Defeated";
                }
            }

        }

        private void Goed(int iets)
        {
            getal.Clear();
            switch (iets)
            {
                case 1:
                    getal.Add(0);
                    getal.Add(0);
                    getal.Add(0);
                    getal.Add(0);
                    getal.Add(0);
                    break;
                case 2:
                    getal.Add(1);
                    getal.Add(1);
                    getal.Add(1);
                    getal.Add(1);
                    getal.Add(1);
                    break;
                case 3:
                    getal.Add(2);
                    getal.Add(2);
                    getal.Add(2);
                    getal.Add(2);
                    getal.Add(2);
                    break;
                case 4:
                    getal.Add(3);
                    getal.Add(3);
                    getal.Add(3);
                    getal.Add(3);
                    getal.Add(3);
                    break;
                case 5:
                    getal.Add(4);
                    getal.Add(4);
                    getal.Add(4);
                    getal.Add(4);
                    getal.Add(4);
                    break;
                case 6:
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    break;
                case 7:
                    getal.Add(0);
                    getal.Add(1);
                    getal.Add(2);
                    getal.Add(3);
                    getal.Add(4);
                    break;
                case 8:
                    getal.Add(1);
                    getal.Add(2);
                    getal.Add(3);
                    getal.Add(4);
                    getal.Add(5);
                    break;
                case 9:
                    getal.Add(4);
                    getal.Add(4);
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    break;
                default:
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    getal.Add(5);
                    break;
            }
        }
    }
}
