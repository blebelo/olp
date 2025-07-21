import React from "react";
import { Modal, Form, Input, Button} from "antd";
import { useStyles } from "./Style/style";
import type { FormInstance, Rule } from "antd/es/form";

export interface FieldConfig {
  label: string;
  name: string;
  rules?: Rule[];
  type?: "input" | "date" | "custom" | "textarea" | "upload";
  component?: React.ReactNode;
}

import type { IInstructor } from "@/providers/instructorProvider/context";

interface ReusableModalFormProps {
  title: string;
  isVisible: boolean;
  onCancel: () => void;
  onSubmit: () => void;
  fields: FieldConfig[];
  form: FormInstance;
  initialValues?: Partial<IInstructor>;
}

const ReusableModalForm: React.FC<ReusableModalFormProps> = ({ title, isVisible, onCancel, onSubmit, fields, form, initialValues }) => {
  const { TextArea } = Input;
  const { styles } = useStyles();

  const renderField = (field: FieldConfig) => {

    if (field.type === "custom" && field.component) {
      return field.component;
    }
    if (field.type === "textarea") {
      return <TextArea rows={4} className={styles.Input} />;
    }

    return <Input className={styles.Input} />;
  };

  return (
    <Modal
      title={title}
      className={styles.CustomModal}
      open={isVisible}
      onOk={onSubmit}
      onCancel={onCancel}
      footer={[
        <Button key="cancel" onClick={onCancel} className={styles.CancelButton}>
          Cancel
        </Button>,
        <Button key="submit" onClick={onSubmit} className={styles.Button}>
          Save
        </Button>,
      ]}
    >
      <Form layout="vertical" form={form} initialValues={initialValues}>
        {fields.map((field) => (
          <Form.Item
            key={field.name}
            label={field.label}
            name={field.name}
            rules={field.rules}
          >
            {renderField(field)}
          </Form.Item>
        ))}
      </Form>
    </Modal>
  );
};

export default ReusableModalForm;