using UnityEngine;
using System.Text;
using TMPro;

public class FSMRuntimeDebugger : MonoBehaviour
{
    public CharacterControllerFSM Controller;
    public TMP_Text DebugText;

    void Update()
    {
        if (Controller == null || DebugText == null)
            return;

        var machine = Controller.machine;

        if (machine == null)
            return;

        StringBuilder builder = new StringBuilder();

        builder.AppendLine("HFSM Debug\n");

        var state = machine.CurrentState;

        if (state != null)
        {
            builder.AppendLine("Current State: " + state.GetType().Name);

            if (state.Parent != null)
                builder.AppendLine("Parent State: " + state.Parent.GetType().Name);

            builder.AppendLine("\nAvailable Transitions:");

            foreach (var t in state.GetTransitions())
            {
                builder.AppendLine("- " + t.TargetState.GetType().Name);
            }
        }

        DebugText.text = builder.ToString();
    }
}