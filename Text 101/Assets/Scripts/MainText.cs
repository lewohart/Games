using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainText : MonoBehaviour {
	internal class Option {
		private Option parent;
		private KeyCode key;
		private string enter;
		private string header;
		private string message;

		private ArrayList options = new ArrayList();

		public Option(KeyCode k, string enter, string header) {
			this.key = k;
			this.enter = enter;
			this.header = header;
		}

		public void AddOption(ArrayList options) {
			this.options.AddRange(options);
			foreach(Option o in this.options)
				o.parent = this;
			SetOptionsMessage();
		}

		private void SetOptionsMessage() {
			message = header + "\n\nPress ";
			foreach(Option o in options)
				message += o.key.ToString() + " to " + (o.options.Contains(parent) ? parent.parent.enter : o.enter) +", ";
			message = message.Remove(message.Length - 2, 2);
		}

		public void Update() {
			foreach(Option o in options) {
				if(Input.GetKeyDown(o.key))
					Current = o;
			}
		}

		public string Message { get { return message; } }
		public static Option Current;
	}

	public Text prompt;
	public string Prompt { set { prompt.text = value; } }

	private void Setup() {
		Option Wellcome = new Option(KeyCode.P, "Start", "Wellcome to the Prison game!");
		Option Cell = new Option(KeyCode.R, "Roaming your cell", "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed, a mirror on the wall, and the door is locked from the outside.");
		Option Sheets0 = new Option(KeyCode.S, "View Sheets", "You can't believe you sleep in these things. Surely it's time somebody changed them. The pleasures of prison life I guess!");
		Option Mirror = new Option(KeyCode.M, "View Mirror", "The dirty old mirror on the wall seems loose.");
		Option Lock0 = new Option(KeyCode.L, "View Lock", "This is one of those button locks. You have no idea what the combination is. You wish you could somehow see where the dirty fingerprints were, maybe that would help.");
		Option CellMirror = new Option(KeyCode.T, "Take the mirror", "You are still in your cell, and you STILL want to escape! There are some dirty sheets on the bed, a mark where the mirror was, and that pesky door is still there, and firmly locked!");
		Option Sheets1 = new Option(KeyCode.S, "View Sheets", "Holding a mirror in your hand doesn't make the sheets look any better.");
		Option Lock1 = new Option(KeyCode.L, "View Lock", "You carefully put the mirror through the bars, and turn it round so you can see the lock. You can just make out fingerprints around the buttons. You press the dirty buttons, and hear a click.");
		Option Corridor0 = new Option(KeyCode.R, "Open the Door", "You're out of your cell, but not out of trouble.You are in the corridor, there's a closet and some stairs leading to the courtyard. There's also various detritus on the floor.");
		Option Stairs0 = new Option(KeyCode.S, "Climb the stairs", "You start walking up the stairs towards the outside light. You realise it's not break time, and you'll be caught immediately. You slither back down the stairs and reconsider.");
		Option Floor = new Option(KeyCode.F, "Inspect the Floor", "Rummagaing around on the dirty floor, you find a hairclip.");
		Option ClosetDoor = new Option(KeyCode.C, "View the Closet", "You are looking at a closet door, unfortunately it's locked. Maybe you could find something around to help enourage it open?");
		Option Stairs1 = new Option(KeyCode.S, "Climb the stairs", "Unfortunately weilding a puny hairclip hasn't given you the confidence to walk out into a courtyard surrounded by armed guards!");
		Option Corridor1 = new Option(KeyCode.C, "Take the Hairclip", "Still in the corridor. Floor still dirty. Hairclip in hand. Now what? You wonder if that lock on the closet would succumb to to some lock-picking?");
		Option InCloset = new Option(KeyCode.U, "Undress", "Inside the closet you see a cleaner's uniform that looks about your size! Seems like your day is looking-up.");
		Option Corridor2 = new Option(KeyCode.R, "Return to the corridor", "Back in the corridor, having declined to dress-up as a cleaner.");
		Option Stairs2 = new Option(KeyCode.S, "Climb the stairs", "You feel smug for picking the closet door open, and are still armed with a hairclip (now badly bent). Even these achievements together don't give you the courage to climb up the staris to your death!");
		Option Corridor3 = new Option(KeyCode.D, "Dress up", "You're standing back in the corridor, now convincingly dressed as a cleaner. You strongly consider the run for freedom.");
		Option Courtyard = new Option(KeyCode.S, "Take the Stairs", "You walk through the courtyard dressed as a cleaner. The guard tips his hat at you as you waltz past, claiming your freedom. You heart races as you walk into the sunset.");
		Option Freedom = new Option(KeyCode.P, "Play again", "You are FREE!");

		Wellcome.AddOption(new ArrayList() { Cell });
		Cell.AddOption(new ArrayList() { Sheets0, Mirror, Lock0 });
		Sheets0.AddOption(new ArrayList() { Cell });
		Mirror.AddOption(new ArrayList() { Cell, CellMirror });
		Lock0.AddOption(new ArrayList() { Cell });
		CellMirror.AddOption(new ArrayList() { Sheets1, Lock1 });
		Sheets1.AddOption(new ArrayList() { CellMirror });
		Lock1.AddOption(new ArrayList() { CellMirror, Corridor0 });
		Corridor0.AddOption(new ArrayList() { Stairs0, Floor, ClosetDoor });
		Stairs0.AddOption(new ArrayList() { Corridor0 });
		Floor.AddOption(new ArrayList() { Corridor0, Corridor1 });
		ClosetDoor.AddOption(new ArrayList() { Corridor0 });
		Corridor1.AddOption(new ArrayList() { Stairs1, InCloset });
		Stairs1.AddOption(new ArrayList() { Corridor1 });
		InCloset.AddOption(new ArrayList() { Corridor2, Corridor3 });
		Corridor2.AddOption(new ArrayList() { InCloset, Stairs2 });
		Stairs2.AddOption(new ArrayList() { Corridor2 });
		Corridor3.AddOption(new ArrayList() { InCloset, Courtyard });
		Courtyard.AddOption(new ArrayList() { Freedom });
		Freedom.AddOption(new ArrayList() { Wellcome });

		Option.Current = Wellcome;
	}

	void Start() {
		Setup();
	}

	void Update() {
		Prompt = Option.Current.Message;
		Option.Current.Update();
	}
}

