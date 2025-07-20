import { Card} from 'antd';
import Image from 'next/image';
import { useStyles } from './Styles/style';

export interface CourseType {
  id: number;
  name: string;
  topic: string;
  description: string;
  thumbnail: string;
};

interface CourseCardProps {
  course: CourseType;
}

const CourseCard: React.FC<CourseCardProps> = ({ course}) => {
  const { styles } = useStyles();

  return (
      <Card
        className={styles.courseCard}
        cover={
          <div style={{ position: 'relative', width: '100%', height: '10rem' }}>
            <Image
              alt={course.name}
              src={course.thumbnail}
              fill
              className={styles.image}
              sizes="(max-width: 768px) 100vw, 33vw"
            />
          </div>
        }
        hoverable
      >
        <Card.Meta
          title={course.name}
          description={
            <>
              <p><strong>Topic:</strong> {course.topic}</p>
              <p>{course.description}</p>
            </>
          }
        />
      </Card>
  );
};

export default CourseCard;