"use client";
import React from "react";
import { Card, Typography, Space, Tag } from "antd";
import { useStyles } from "../Style/style"

const sampleQuizResults = [
  {
    question: "What is the capital of France?",
    options: ["Madrid", "Berlin", "Paris", "Rome"],
    correctAnswerIndex: 2,
    studentAnswerIndex: 1,
  },
  {
    question: "Which language is primarily spoken in Brazil?",
    options: ["Spanish", "French", "Portuguese", "English"],
    correctAnswerIndex: 2,
    studentAnswerIndex: 2,
  },
];

const QuizResultsPage: React.FC = () => {
  const { styles } = useStyles();

  return (
    <div className={styles.page}>
      <Card className={styles.card}>
        <Typography.Title level={3} className={styles.title}>
          Quiz Results
        </Typography.Title>
        <Space direction="vertical" size="large" className={styles.questions}>
          {sampleQuizResults.map((q, index) => {
            const isCorrect = q.studentAnswerIndex === q.correctAnswerIndex;
            return (
              <div key={index} className={styles.questionBlock}>
                <Typography.Text className={styles.questionText}>
                  {index + 1}. {q.question}
                </Typography.Text>

                <Space direction="vertical" className={styles.options}>
                  {q.options.map((opt, i) => {
                    const isSelected = i === q.studentAnswerIndex;
                    const isCorrectAnswer = i === q.correctAnswerIndex;

                    return (
                      <div key={i}>
                        <Typography.Text
                          strong={isSelected || isCorrectAnswer}
                          style={{
                            color: isSelected
                              ? isCorrect
                                ? "#389e0d" // green
                                : "#cf1322" // red
                              : isCorrectAnswer && !isCorrect
                              ? "#389e0d"
                              : "#444",
                          }}
                        >
                          {opt}
                          {isSelected && (
                            <Tag color={isCorrect ? "green" : "red"} style={{ marginLeft: 8 }}>
                              Your Answer
                            </Tag>
                          )}
                          {isCorrectAnswer && !isCorrect && (
                            <Tag color="green" style={{ marginLeft: 8 }}>
                              Correct Answer
                            </Tag>
                          )}
                        </Typography.Text>
                      </div>
                    );
                  })}
                </Space>
              </div>
            );
          })}
        </Space>
      </Card>
    </div>
  );
};

export default QuizResultsPage;
