"use client";
import React from "react";
import { Modal, Form, Input, Button, Typography } from "antd";
import { useStyles } from "./Style/style";

export interface QuizQuestion {
    question: string;
    options: string[];
    correctAnswer: number;
};

interface QuizModalFormProps {
    visible: boolean;
    onCancel: () => void;
    onSubmit: (questions: QuizQuestion[]) => void;
    questions: QuizQuestion[];
    setQuestions: React.Dispatch<React.SetStateAction<QuizQuestion[]>>;
}

const QuizModalForm: React.FC<QuizModalFormProps> = ({ visible, onCancel, onSubmit, questions, setQuestions }) => {

    const { styles } = useStyles();

    return (
        <Modal
            title="Add Quiz"
            className={styles.Container}
            open={visible}
            onCancel={onCancel}
            onOk={() => onSubmit(questions)}
            width={700}
            okText="Save Quiz"
        >
            {questions.map((q, index) => (
                <div key={index} className={styles.QuestionBlock}>
                    <Typography.Text className={styles.QuestionTitle}>
                        Question {index + 1}
                    </Typography.Text>
                    <Form.Item>
                        <Input
                            placeholder="Enter your question"
                            value={q.question}
                            onChange={(e) => {
                                const newQs = [...questions];
                                newQs[index].question = e.target.value;
                                setQuestions(newQs);
                            }}
                        />
                    </Form.Item>
                    {q.options.map((opt, optIndex) => (
                        <Form.Item key={optIndex} className={styles.OptionInput}>
                            <Input
                                placeholder={`Option ${optIndex + 1}`}
                                value={opt}
                                onChange={(e) => {
                                    const newQs = [...questions];
                                    newQs[index].options[optIndex] = e.target.value;
                                    setQuestions(newQs);
                                }}
                                addonBefore={
                                    <input
                                        type="radio"
                                        name={`correct-${index}`}
                                        checked={q.correctAnswer === optIndex}
                                        onChange={() => {
                                            const newQs = [...questions];
                                            newQs[index].correctAnswer = optIndex;
                                            setQuestions(newQs);
                                        }}
                                    />
                                }
                            />
                        </Form.Item>
                    ))}
                </div>
            ))}
            <Button
                type="dashed"
                block
                className={styles.AddButton}
                onClick={() =>
                    setQuestions([
                        ...questions,
                        { question: "", options: ["", "", "", ""], correctAnswer: 0 },
                    ])
                }
            >
                + Add Another Question
            </Button>
        </Modal>
    );
};

export default QuizModalForm;