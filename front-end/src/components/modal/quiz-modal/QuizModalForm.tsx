"use client";
import React from "react";
import { Modal, Form, Input, Button, Typography, InputNumber } from "antd";
import { useStyles } from "./Style/style";

export interface IQuiz {
  name: string;
  description: string;
  duration: string;
  passingScore: number;
  courseId: string;
  questions: string[];
  answerOptions: {
    correctIndex: number;
    possibleAnswers: string[];
  }[];
}

interface QuizModalFormProps {
  visible: boolean;
  onCancel: () => void;
  onSubmit: (quiz: IQuiz) => void;
  quiz: IQuiz;
  setQuiz: React.Dispatch<React.SetStateAction<IQuiz>>;
}

const QuizModalForm: React.FC<QuizModalFormProps> = ({ 
  visible, 
  onCancel, 
  onSubmit, 
  quiz, 
  setQuiz 
}) => {
  const { styles } = useStyles();

  const defaultQuiz: IQuiz = {
    name: "",
    description: "",
    duration: "",
    passingScore: 70,
    courseId: "",
    questions: [],
    answerOptions: []
  };

  const currentQuiz: IQuiz = {
    name: quiz?.name || defaultQuiz.name,
    description: quiz?.description || defaultQuiz.description,
    duration: quiz?.duration || defaultQuiz.duration,
    passingScore: quiz?.passingScore || defaultQuiz.passingScore,
    courseId: quiz?.courseId || defaultQuiz.courseId,
    questions: quiz?.questions || defaultQuiz.questions,
    answerOptions: quiz?.answerOptions || defaultQuiz.answerOptions,
  };

  const addQuestion = () => {
    const updatedQuiz = {
      ...currentQuiz,
      questions: [...(currentQuiz.questions || []), ""],
      answerOptions: [
        ...(currentQuiz.answerOptions || []),
        { correctIndex: 0, possibleAnswers: ["", "", "", ""] }
      ]
    };
    setQuiz(updatedQuiz);
  };

  const updateQuizField = (field: keyof IQuiz, value: any) => {
    setQuiz({ ...currentQuiz, [field]: value });
  };

  const updateQuestion = (index: number, value: string) => {
    const newQuestions = [...(currentQuiz.questions || [])];
    newQuestions[index] = value;
    setQuiz({ ...currentQuiz, questions: newQuestions });
  };

  const updateAnswerOption = (questionIndex: number, optionIndex: number, value: string) => {
    const newAnswerOptions = [...(currentQuiz.answerOptions || [])];
    if (!newAnswerOptions[questionIndex]) {
      newAnswerOptions[questionIndex] = { correctIndex: 0, possibleAnswers: ["", "", "", ""] };
    }
    newAnswerOptions[questionIndex].possibleAnswers[optionIndex] = value;
    setQuiz({ ...currentQuiz, answerOptions: newAnswerOptions });
  };

  const updateCorrectAnswer = (questionIndex: number, correctIndex: number) => {
    const newAnswerOptions = [...(currentQuiz.answerOptions || [])];
    if (!newAnswerOptions[questionIndex]) {
      newAnswerOptions[questionIndex] = { correctIndex: 0, possibleAnswers: ["", "", "", ""] };
    }
    newAnswerOptions[questionIndex].correctIndex = correctIndex;
    setQuiz({ ...currentQuiz, answerOptions: newAnswerOptions });
  };

  return (
    <Modal
      title="Add Quiz"
      className={styles.Container}
      open={visible}
      onCancel={onCancel}
      onOk={() => onSubmit(currentQuiz)}
      width={800}
      okText="Save Quiz"
    >
  
      <div className={styles.Container}>
        <Typography.Title level={4}>Quiz Information</Typography.Title>
        
        <Form.Item label="Quiz Name">
          <Input
            placeholder="Enter quiz name"
            value={currentQuiz.name}
            onChange={(e) => updateQuizField('name', e.target.value)}
          />
        </Form.Item>

        <Form.Item label="Description">
          <Input.TextArea
            placeholder="Enter quiz description"
            value={currentQuiz.description}
            onChange={(e) => updateQuizField('description', e.target.value)}
            rows={3}
          />
        </Form.Item>

        <Form.Item label="Duration">
          <Input
            placeholder="e.g., 00:30:00 For 30 Minutes"
            value={currentQuiz.duration}
            onChange={(e) => updateQuizField('duration', e.target.value)}
          />
        </Form.Item>

        <Form.Item label="Passing Score (%)">
          <InputNumber
            min={0}
            max={100}
            value={currentQuiz.passingScore}
            onChange={(value) => updateQuizField('passingScore', value || 0)}
            style={{ width: '100%' }}
          />
        </Form.Item>

      </div>

      <Typography.Title level={4}>Questions</Typography.Title>
      
      {(currentQuiz.questions || []).map((question, questionIndex) => (
        <div key={questionIndex} className={styles.QuestionBlock}>
          <Typography.Text className={styles.QuestionTitle}>
            Question {questionIndex + 1}
          </Typography.Text>
          
          <Form.Item>
            <Input
              placeholder="Enter your question"
              value={question}
              onChange={(e) => updateQuestion(questionIndex, e.target.value)}
            />
          </Form.Item>

          {(currentQuiz.answerOptions[questionIndex]?.possibleAnswers || []).map((option, optionIndex) => (
            <Form.Item key={optionIndex} className={styles.OptionInput}>
              <Input
                placeholder={`Option ${optionIndex + 1}`}
                value={option}
                onChange={(e) => updateAnswerOption(questionIndex, optionIndex, e.target.value)}
                addonBefore={
                  <input
                    type="radio"
                    name={`correct-${questionIndex}`}
                    checked={currentQuiz.answerOptions[questionIndex]?.correctIndex === optionIndex}
                    onChange={() => updateCorrectAnswer(questionIndex, optionIndex)}
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
        onClick={addQuestion}
      >
        + Add Another Question
      </Button>
    </Modal>
  );
};

export default QuizModalForm;