"use client";
import React, {useState} from "react";
import { Card, Button, Typography, Radio, Space } from "antd";
import { useStyles} from "./Style/style";

const sampleQuiz = [
  {
    question: "What is the output of `typeof null` in JavaScript?",
    options: ["'null'", "'object'", "'undefined'", "'number'"],
    correctAnswerIndex: 1,
  },
  {
    question: "Which of the following is a primitive data type in JavaScript?",
    options: ["Object", "Function", "Boolean", "Array"],
    correctAnswerIndex: 2,
  },
  {
    question: "What is the difference between `==` and `===`?",
    options: [
      "`==` compares values only, `===` compares values and types",
      "`===` compares values only, `==` compares values and types",
      "They are the same",
      "`===` is deprecated",
    ],
    correctAnswerIndex: 0,
  },
  {
    question: "What will `console.log([] + {})` output?",
    options: ["'[object Object]'", "'[object Object]'", "'0'", "'undefined'"],
    correctAnswerIndex: 0,
  },
  {
    question: "Which method is used to add an element to the end of an array?",
    options: ["push()", "unshift()", "add()", "append()"],
    correctAnswerIndex: 0,
  },
  {
    question: "What does `NaN` stand for?",
    options: ["Not a Node", "New and Null", "Not a Number", "Null and Nothing"],
    correctAnswerIndex: 2,
  },
  {
    question: "What is a closure in JavaScript?",
    options: [
      "A function that calls itself",
      "A variable that never changes",
      "A function that remembers variables from its outer scope",
      "An error handling block",
    ],
    correctAnswerIndex: 2,
  },
  {
    question: "Which keyword is used to declare a constant in JavaScript?",
    options: ["let", "var", "const", "define"],
    correctAnswerIndex: 2,
  },
  {
    question: "How do you write a comment in JavaScript?",
    options: ["<!-- Comment -->", "// Comment", "# Comment", "** Comment **"],
    correctAnswerIndex: 1,
  },
  {
    question: "Which of the following is falsy in JavaScript?",
    options: ["'false'", "0", "[]", "'0'"],
    correctAnswerIndex: 1,
  },
];


const QuizPage: React.FC = () => {
  const { styles } = useStyles();
  const [answers, setAnswers] = useState<(number | null)[]>(
    Array(sampleQuiz.length).fill(null)
  );

  const handleSelect = (questionIndex: number, optionIndex: number) => {
    const updated = [...answers];
    updated[questionIndex] = optionIndex;
    setAnswers(updated);
  };

  const handleSubmit = () => {
    console.log("Submitted Answers:", answers);
    // Add actual submit logic (API call, etc.)
  };

  return (
    <div className={styles.page}>
      <Card className={styles.card}>
        <Typography.Title level={3} className={styles.title}>
          Course Quiz
        </Typography.Title>
        <Space direction="vertical" size="large" className={styles.questions}>
          {sampleQuiz.map((q, index) => (
            <div key={index} className={styles.questionBlock}>
              <Typography.Text className={styles.questionText}>
                {index + 1}. {q.question}
              </Typography.Text>
              <Radio.Group
                onChange={(e) => handleSelect(index, e.target.value)}
                value={answers[index]}
                className={styles.options}
              >
                {q.options.map((opt, i) => (
                  <Radio key={i} value={i}>
                    {opt}
                  </Radio>
                ))}
              </Radio.Group>
            </div>
          ))}
          <Button
            type="primary"
            onClick={handleSubmit}
            disabled={answers.includes(null)}
            className={styles.submit}
          >
            Submit Quiz
          </Button>
        </Space>
      </Card>
    </div>
  );
};

export default QuizPage;