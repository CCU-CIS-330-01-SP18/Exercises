using System;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// Represents a member of an association. Can vote on propositions when asked, behaving in accord with a randomly-generated voting personality.
    /// </summary>
    public class Member : Individual
    {
        public bool LiarAndScoundrel { get; set; }
        public Personality Personality { get; set; }

        /// <summary>
        /// Initializes a new instance of the Member class, with a randomized voting personality and liar status.
        /// </summary>
        public Member()
        {
            Random random = new Random();
            int personalityCode = random.Next(4);
            int liarCode = random.Next(2);

            switch (personalityCode)
            {
                case 0:
                    this.Personality = Personality.YesMan;
                    break;

                case 1:
                    this.Personality = Personality.GrouchyJerk;
                    break;

                case 2:
                    this.Personality = Personality.SwingVoter;
                    break;

                case 3:
                    this.Personality = Personality.OverlyDeliberative;
                    break;

                default:
                    this.Personality = Personality.SwingVoter;
                    break;
            }

            if (liarCode == 1)
            {
                this.LiarAndScoundrel = true;
            }
            else
            {
                this.LiarAndScoundrel = false;
            }
        }

        /// <summary>
        /// Vote on a proposal, based on voting personality.
        /// </summary>
        /// <returns>A vote type depending on their voting personality.</returns>
        public VoteType Vote()
        {
            Random random = new Random();
            switch (this.Personality)
            {
                case Personality.YesMan:
                    if (this.LiarAndScoundrel)
                    {
                        return VoteType.Nay;
                    }
                    else
                    {
                        return VoteType.Yea;
                    }

                case Personality.GrouchyJerk:
                    if (this.LiarAndScoundrel)
                    {
                        return VoteType.Yea;
                    }
                    else
                    {
                        return VoteType.Nay;
                    }

                case Personality.SwingVoter:
                    int vote = random.Next(2);
                    if (vote == 0)
                    {
                        return VoteType.Nay;
                    }
                    else
                    {
                        return VoteType.Yea;
                    }

                case Personality.OverlyDeliberative:
                    // Has a 50% chance of failing to vote at all and returning Abstain.
                    if (random.Next(2) == 1)
                    {
                        goto default;
                    }
                    else
                    {
                        goto case Personality.SwingVoter;
                    }

                default:
                    return VoteType.Abstain;
            }
        }
    }
}
