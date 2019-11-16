using Accord.Math;
using Accord.Statistics.Kernels;
using KerasSharp;
using KerasSharp.Activations;
using KerasSharp.Initializers;
using KerasSharp.Losses;
using KerasSharp.Metrics;
using KerasSharp.Models;
using KerasSharp.Optimizers;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumSharp;
using System.IO;

namespace Tests.Learning
{
    class DQNClass
    {
        double GAMMA = 0.90;
        double LEARNING_RATE = 0.0001;
        int MEMORY_SIZE = 100000;
        int BATCH_SIZE = 32;
        double EXPLORATION_MAX = 1.0;
        double EXPLORATION_MIN = 0.01;
        double EXPLORATION_DECAY = 0.995;
        double exploration_rate;
        int action_space;
        Queue<objectclass> memory = new Queue<objectclass>();
        Sequential model = new Sequential();
        public DQNClass(int observation_space, int action_space)
        {
            this.exploration_rate = EXPLORATION_MAX;
            this.action_space = action_space;
            //  var model = new Sequential();
            model.Add(new Dense(128, input_dim: observation_space, activation: new ReLU()));
            model.Add(new Dense(128, activation: new ReLU()));
            //This linear is implemented by me
            //  model.Add(new Dense(this.action_space, activation: new KerasSharp.Activations.Linear()));
            model.Compile(loss: "mse", optimizer: new Adam(lr: LEARNING_RATE));
        }
        /*public void set_model(string name)
         {
            this.model = model.LoadModel(name);
        }*/

        public void Save_model(string name)
        {
            string json = this.model.ToJson();
            File.WriteAllText("model.json", json);
            //this.model.SaveWeight(name + " Weight");
            this.model.Save(name + "Save");
        }


        public void Load_model(string name)
        {
            var loaded_model = Sequential.ModelFromJson(File.ReadAllText("model.json"));
            loaded_model.LoadWeight(name);
            loaded_model.LoadModel(name);
        }

        public void remember(Array state, int action, int reward, Array next_state, bool done)
        {
            objectclass oc = new objectclass(state, action, reward, next_state, done);
            this.memory.Enqueue(oc);
        }

        public double act(Array state)
        {
            Random random = new Random();
            if (np.random.rand() < this.exploration_rate)
            {
                int actionindex = random.Next(0, this.action_space);
                return actionindex;
            }
            //var model = new Sequential();
            Array[] pred = model.predict(state);
            return np.argmax(pred[0]);
        }

        public void experience_replay()
        {

            if (this.memory.Count < this.BATCH_SIZE)
            {
                return;
            }
            Queue<objectclass> batch = new Queue<objectclass>();
            Random random = new Random();
            batch = this.RandomSample(this.memory, this.BATCH_SIZE);
            Array state;
            int action;
            int reward;
            bool done;
            Array next_state;
            int q_update = 0;
            //Array[] q_values;
            foreach (objectclass obj in batch)
            {
                state = obj.state;
                action = obj.action;
                reward = obj.reward;
                next_state = obj.next_state;
                done = obj.done;
                q_update = reward;
                if (!(done))
                {
                    q_update = (reward + GAMMA * np.amax(this.model.predict(next_state)[0]));
                }
                int verbose = 0;
                int[] q_values = this.model.predict(state).ToInt32();
                q_values[action] = q_update;
                this.model.fit(state, q_values, verbose);

            }
            this.exploration_rate *= EXPLORATION_DECAY;
            this.exploration_rate = Math.Max(EXPLORATION_MIN, this.exploration_rate);
        }

        public Queue<objectclass> RandomSample(Queue<objectclass> Memory, int batchsize)
        {
            //3-Algo of  https://codereview.stackexchange.com/questions/188610/20-ways-to-do-random-sampling
            //Memory = Memory.DeepCopy();
            int TotalLength = Memory.Count;
            Queue<objectclass> Sample = new Queue<objectclass>();
            int idx = 0;
            while (Sample.Count < batchsize)
            {
                Random rnd = new Random();
                idx = rnd.Next(0, TotalLength);
                if (!(Sample.Contains(Memory.ElementAtOrDefault(idx))))
                {
                    Sample.Enqueue(Memory.ElementAtOrDefault(idx));
                }
            }
            return Sample;


        }
    }

    class objectclass
    {
        public Array state;
        public int action;
        public int reward;
        public Array next_state;
        public bool done;
        public objectclass()
        {

        }
        public objectclass(Array state, int action, int reward, Array next_state, bool done)
        {
            this.state = state;
            this.action = action;
            this.reward = reward;
            this.next_state = next_state;
            this.done = done;
        }
    }

}