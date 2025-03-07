import React, { useState } from "react";
import "./AlgorithmInputBox.css";
import ToolTip from "../ToolTip/ToolTip";

// Declaring AlgorithmInputBox component
function AlgorithmInputBox({
  setCustomInputArray,
  setIsPlaying,
}: {
  setCustomInputArray: React.Dispatch<React.SetStateAction<number[]>>;
  setIsPlaying: React.Dispatch<React.SetStateAction<boolean>>;
}) {
  const [customInput, setCustomInput] = useState<string>(""); // State for custom input string
  const [errorMessage, setErrorMessage] = useState<string>(""); // State for error message

  // Function to handle change in custom input
  const handleCustomInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCustomInput(e.target.value);
  };
  // Processing custom input string into an array of valid numbers
  const handleCustomInputSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const inputArray = customInput
      .trim()
      .split(/[,\s]+/)
      .filter(
        (num) => !isNaN(Number(num)) && Number(num) >= 0 && Number(num) <= 100
      )
      .map((num) => Number(num));

    // Validating the input array
    if (inputArray.length < 2) {
      setErrorMessage("Please enter one or more positive numbers.");
    } else {
      setErrorMessage("");
      setCustomInputArray(inputArray);
    }
    setIsPlaying(false);
  };

  // Rendering AlgorithmInputBox component
  return (
    <div className="customInputs">
      <h2
        style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <span>Custom Input values</span>
        <span style={{ marginLeft: "5px" }}>
          <ToolTip customMessage="Please separate numbers by a comma or space. Any other inputs will be ignored. Inputs must be positive and under 100." />
        </span>
      </h2>

      <form onSubmit={handleCustomInputSubmit}>
        <input
          type="text"
          name="inputs"
          value={customInput}
          onChange={handleCustomInputChange}
        />
        <button type="submit">Submit</button>
      </form>
      {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
    </div>
  );
}

export default AlgorithmInputBox;
