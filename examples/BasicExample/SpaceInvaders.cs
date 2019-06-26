using Gym;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasicExample
{
    public class SpaceInvaders
    {
        public static void Run()
        {
            Build();
        }

        private static void Build()
        {
            var env = gym.Make("SpaceInvaders-v0");
            env.Seed(0);
            
            int num_episodes = 10;
            List<float> rewards = new List<float>();

            for (int i = 0; i < num_episodes; i++)
            {
                env.Reset();
                float episode_reward = 0;

                while (true)
                {
                    var action = env.ActionSpace.Sample();
                    var stepResult = env.Step(action);
                    episode_reward += stepResult.Reward;
                    if (stepResult.Done)
                    {
                        Console.WriteLine("Reward: " + episode_reward);
                        rewards.Add(episode_reward);
                        break;
                    }
                }
            }

            Console.WriteLine("Average Reward: " + rewards.Average());
        }
    }
}
